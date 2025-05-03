using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32; // Ajout pour la récupération du type MIME

namespace AgOpenGPS
{
    public class GoogleDriveSynchronizer
    {
        private readonly string _localFolderPath;
        private readonly string _driveFolderName;
        private readonly string _credentialsFilePath;
        private readonly string _applicationName;
        private DriveService _driveService;
        private string _driveFolderId;
        private readonly SemaphoreSlim _uploadSemaphore = new SemaphoreSlim(3); // Limite à 3 uploads parallèles
        private readonly SemaphoreSlim _downloadSemaphore = new SemaphoreSlim(3); // Limite à 3 downloads parallèles

        public event EventHandler<SynchronizationProgressEventArgs> SynchronizationProgressChanged;

        public class SynchronizationProgressEventArgs : EventArgs
        {
            public int FilesProcessed { get; set; }
            public int TotalFiles { get; set; }
            public string OperationType { get; set; } // "Upload" ou "Download"

            public SynchronizationProgressEventArgs()
            {
                FilesProcessed = 0;
            }
        }

        public GoogleDriveSynchronizer(string localFolderPath, string driveFolderName, string credentialsFilePath, string applicationName)
        {
            _localFolderPath = localFolderPath;
            _driveFolderName = driveFolderName;
            _credentialsFilePath = credentialsFilePath;
            _applicationName = applicationName;
        }

        public async Task InitializeAsync()
        {
            UserCredential credential;
            using (var stream = new FileStream(_credentialsFilePath, FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { DriveService.Scope.Drive },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).ConfigureAwait(false);
                // Console.WriteLine("Credential file saved to: " + credPath);
            }

            _driveService = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = _applicationName,
            });

            _driveFolderId = await GetOrCreateDriveFolderAsync(_driveFolderName);
        }

        private async Task<string> GetOrCreateDriveFolderAsync(string folderName)
        {
            var request = _driveService.Files.List();
            request.Q = $"name='{folderName}' and mimeType='application/vnd.google-apps.folder' and trashed=false";
            request.Fields = "files(id)";
            var response = await request.ExecuteAsync();
            var folder = response.Files.FirstOrDefault();
            if (folder == null)
            {
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder"
                };
                var createRequest = _driveService.Files.Create(fileMetadata);
                var createdFolder = await createRequest.ExecuteAsync();
                return createdFolder.Id;
            }
            return folder.Id;
        }

        public Dictionary<string, FileInfo> GetLocalFiles(string path)
        {
            return Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                            .ToDictionary(f => f.Substring(path.Length + 1).Replace('\\', '/'), f => new FileInfo(f));
        }

        public async Task<Dictionary<string, Google.Apis.Drive.v3.Data.File>> GetDriveFilesAsync(string parentId = null, string currentPath = "")
        {
            var fileList = new Dictionary<string, Google.Apis.Drive.v3.Data.File>();
            string pageToken = null;
            Google.Apis.Drive.v3.Data.FileList response = null;

            var request = _driveService.Files.List();
            request.Q = $"'{parentId ?? _driveFolderId}' in parents and trashed=false";
            request.Fields = "nextPageToken, files(id, name, mimeType, size)";

            do
            {
                response = await request.ExecuteAsync();
                if (response?.Files != null)
                {
                    foreach (var file in response.Files)
                    {
                        string path = currentPath;
                        if (!string.IsNullOrEmpty(path))
                        {
                            path += "/" + file.Name;
                        }
                        else if (parentId == null && file.Id == _driveFolderId)
                        {
                            path = ""; // Racine
                        }
                        else
                        {
                            path = file.Name;
                        }

                        if (file.MimeType != "application/vnd.google-apps.folder")
                        {
                            fileList[path] = file;
                        }
                        else
                        {
                            var subFiles = await GetDriveFilesAsync(file.Id, path);
                            foreach (var subFile in subFiles)
                            {
                                fileList[subFile.Key] = subFile.Value;
                            }
                        }
                    }
                    pageToken = response.NextPageToken;
                }
                request.PageToken = pageToken;
            } while (pageToken != null);

            return fileList;
        }

        private string GetMimeType(string fileName)
        {
            string mimeType = "application/octet-stream";
            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(Path.GetExtension(fileName).ToLower());
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        public async Task UploadLocalToDriveAsync(Dictionary<string, FileInfo> localFiles, Dictionary<string, Google.Apis.Drive.v3.Data.File> driveFiles)
        {
            // Console.WriteLine("Téléversement du local vers Google Drive (écraser si existe) en parallèle...");
            var uploadTasks = new List<Task>();
            int totalFiles = localFiles.Count;
            int filesProcessed = 0;

            foreach (var localFileEntry in localFiles)
            {
                string relativePath = localFileEntry.Key;
                FileInfo localFileInfo = localFileEntry.Value;
                string driveFileId = driveFiles.ContainsKey(relativePath) ? driveFiles[relativePath].Id : null;

                await _uploadSemaphore.WaitAsync();
                uploadTasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        await UploadFileToDriveAsync(localFileInfo, relativePath, driveFileId);
                        Interlocked.Increment(ref filesProcessed);
                        SynchronizationProgressChanged?.Invoke(this, new SynchronizationProgressEventArgs { FilesProcessed = filesProcessed, TotalFiles = totalFiles, OperationType = "Upload" });
                    }
                    finally
                    {
                        _uploadSemaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(uploadTasks);
            // Console.WriteLine("Téléversement vers Google Drive terminé.");
        }

        private async Task UploadFileToDriveAsync(FileInfo localFile, string relativePath, string driveFileId = null)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(localFile.Name),
                Parents = new List<string>() { _driveFolderId }
            };

            if (!string.IsNullOrEmpty(Path.GetDirectoryName(relativePath)))
            {
                string[] subfolders = Path.GetDirectoryName(relativePath).Split('/');
                string currentParentId = _driveFolderId;
                foreach (var folderName in subfolders)
                {
                    var request = _driveService.Files.List();
                    request.Q = $"name='{folderName}' and mimeType='application/vnd.google-apps.folder' and '{currentParentId}' in parents and trashed=false";
                    request.Fields = "files(id)";
                    var response = await request.ExecuteAsync();
                    var subFolder = response.Files.FirstOrDefault();
                    if (subFolder == null)
                    {
                        var folderMetadata = new Google.Apis.Drive.v3.Data.File()
                        {
                            Name = folderName,
                            MimeType = "application/vnd.google-apps.folder",
                            Parents = new List<string>() { currentParentId }
                        };
                        var createRequest = _driveService.Files.Create(folderMetadata);
                        var createdSubFolder = await createRequest.ExecuteAsync();
                        currentParentId = createdSubFolder.Id;
                    }
                    else
                    {
                        currentParentId = subFolder.Id;
                    }
                    fileMetadata.Parents = new List<string>() { currentParentId };
                }
            }

            using (var stream = new FileStream(localFile.FullName, FileMode.Open))
            {
                if (driveFileId == null)
                {
                    var uploadRequest = _driveService.Files.Create(fileMetadata, stream, GetMimeType(localFile.Name));
                    await uploadRequest.UploadAsync();
                    // Console.WriteLine($"Téléversé : {relativePath}");
                }
                else
                {
                    var updateRequest = _driveService.Files.Update(fileMetadata, driveFileId, stream, GetMimeType(localFile.Name));
                    await updateRequest.UploadAsync();
                    // Console.WriteLine($"Mis à jour : {relativePath}");
                }
            }
        }

        public async Task DownloadNewFromDriveToLocalAsync(Dictionary<string, FileInfo> localFiles, Dictionary<string, Google.Apis.Drive.v3.Data.File> driveFiles)
        {
            // Console.WriteLine("Téléchargement de Drive vers le local (si inexistant localement) en parallèle...");
            var downloadTasks = new List<Task>();
            int totalFiles = driveFiles.Count(df => !localFiles.ContainsKey(df.Key) && df.Value.MimeType != "application/vnd.google-apps.folder");
            int filesProcessed = 0;

            foreach (var driveFileEntry in driveFiles.Where(df => !localFiles.ContainsKey(df.Key)))
            {
                string relativePath = driveFileEntry.Key;
                Google.Apis.Drive.v3.Data.File driveFile = driveFileEntry.Value;
                string localPath = Path.Combine(_localFolderPath, relativePath.Replace('/', '\\'));

                // Console.WriteLine($"[DOWNLOAD] Nom du fichier/dossier Drive : '{driveFile.Name}', ID : '{driveFile.Id}', Type MIME : '{driveFile.MimeType}'");
                // Console.WriteLine($"[DOWNLOAD] Chemin relatif depuis Drive : '{relativePath}'");
                // Console.WriteLine($"[DOWNLOAD] Chemin local de base : '{_localFolderPath}'");
                // Console.WriteLine($"[DOWNLOAD] Chemin local construit AVANT vérification : '{localPath}'");

                if (driveFile.MimeType == "application/vnd.google-apps.folder")
                {
                    if (!Directory.Exists(localPath))
                    {
                        Directory.CreateDirectory(localPath);
                        // Console.WriteLine($"[DOWNLOAD] Création du dossier local : '{localPath}'");
                    }
                }
                else
                {
                    await _downloadSemaphore.WaitAsync();
                    downloadTasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            // Créer le répertoire parent si nécessaire
                            string localDir = Path.GetDirectoryName(localPath);
                            if (!string.IsNullOrEmpty(localDir) && !Directory.Exists(localDir))
                            {
                                Directory.CreateDirectory(localDir);
                                // Console.WriteLine($"[DOWNLOAD] Création du répertoire parent : '{localDir}'");
                            }
                            await DownloadFileFromDriveAsync(driveFile, localPath);
                            Interlocked.Increment(ref filesProcessed);
                            SynchronizationProgressChanged?.Invoke(this, new SynchronizationProgressEventArgs { FilesProcessed = filesProcessed, TotalFiles = totalFiles, OperationType = "Download" });
                        }
                        finally
                        {
                            _downloadSemaphore.Release();
                        }
                    }));
                }
            }

            await Task.WhenAll(downloadTasks);
            // Console.WriteLine("Téléchargement depuis Google Drive terminé.");
        }

        private async Task DownloadFileFromDriveAsync(Google.Apis.Drive.v3.Data.File driveFile, string localPath)
        {
            try
            {
                var request = _driveService.Files.Get(driveFile.Id);
                var stream = await request.ExecuteAsStreamAsync();

                Directory.CreateDirectory(Path.GetDirectoryName(localPath));
                using (var fileStream = new FileStream(localPath, FileMode.Create, FileAccess.Write))
                {
                    await stream.CopyToAsync(fileStream);
                }
                // Console.WriteLine($"[DOWNLOAD] Téléchargé : '{driveFile.Name}' vers '{localPath}'");
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"[DOWNLOAD] Erreur lors du téléchargement de '{driveFile.Name}': {ex.Message}");
            }
        }
    }
}