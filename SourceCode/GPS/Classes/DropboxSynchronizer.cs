using Dropbox.Api;
using Dropbox.Api.Files; // Nécessaire pour WriteMode, Metadata, etc.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AgOpenGPS // Assurez-vous que cet espace de noms correspond à votre projet
{
    public class DropboxSynchronizer
    {
        private readonly string _localFolderPath;
        private readonly string _dropboxFolderPath; // Doit commencer par '/' s'il n'est pas vide
        // private readonly string _accessToken; // Supprimé
        private readonly DropboxClient _client; // Maintenant initialisé via le constructeur

        private readonly SemaphoreSlim _uploadSemaphore = new SemaphoreSlim(3); // Limite à 3 uploads parallèles
        private readonly SemaphoreSlim _downloadSemaphore = new SemaphoreSlim(3); // Limite à 3 downloads parallèles;

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

        // *** CONSTRUCTEUR MODIFIÉ ***
        // N'accepte plus le token, mais une instance du client Dropbox déjà authentifiée
        public DropboxSynchronizer(string localFolderPath, string dropboxFolderPath, DropboxClient client)
        {
            _localFolderPath = localFolderPath;
            // Assurer que le chemin Dropbox commence par '/' s'il n'est pas vide et n'est pas déjà la racine "/"
            _dropboxFolderPath = dropboxFolderPath.Trim('/');
            if (!string.IsNullOrEmpty(_dropboxFolderPath))
            {
                _dropboxFolderPath = "/" + _dropboxFolderPath;
            }
            else
            {
                _dropboxFolderPath = ""; // Pour représenter la racine de Dropbox
            }

            // Initialise le client avec l'instance fournie
            _client = client; // <-- Utilise l'instance passée en paramètre

            // Les sémaphores sont initialisés comme avant
        }

        // Les méthodes suivantes (GetLocalFiles, GetDropboxFilesAsync, DownloadNewFromDropboxToLocalAsync,
        // UploadLocalToDropboxAsync, LogFileLists) restent inchangées dans leur logique interne
        // car elles utilisent déjà le membre _client.

        public Dictionary<string, FileInfo> GetLocalFiles(string path)
        {
            // ... (code inchangé) ...
            if (!Directory.Exists(path))
            {
                return new Dictionary<string, FileInfo>();
            }
            try
            {
                return Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                               .ToDictionary(f => f.Substring(path.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Replace('\\', '/'),
                                            f => new FileInfo(f));
            }
            catch (UnauthorizedAccessException)
            {
                return new Dictionary<string, FileInfo>();
            }
            catch (Exception)
            {
                return new Dictionary<string, FileInfo>();
            }
        }


        public async Task<Dictionary<string, Metadata>> GetDropboxFilesAsync(string dropboxPathToList)
        {
            // ... (code inchangé, utilise _client) ...
            var fileList = new Dictionary<string, Metadata>();
            try
            {
                var list = await _client.Files.ListFolderAsync(dropboxPathToList, recursive: true);

                while (true)
                {
                    foreach (var item in list.Entries.Where(i => i.IsFile))
                    {
                        string fullPath = item.PathDisplay;
                        string relativePath = fullPath;

                        if (!string.IsNullOrEmpty(_dropboxFolderPath))
                        {
                            if (fullPath.StartsWith(_dropboxFolderPath + "/", StringComparison.OrdinalIgnoreCase))
                            {
                                relativePath = fullPath.Substring(_dropboxFolderPath.Length + 1);
                            }
                            else if (fullPath.Equals(_dropboxFolderPath, StringComparison.OrdinalIgnoreCase))
                            {
                                continue;
                            }
                            else
                            {
                                if (_dropboxFolderPath == "" && !fullPath.Contains("/"))
                                {
                                    relativePath = fullPath.TrimStart('/');
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            relativePath = fullPath.TrimStart('/');
                        }

                        if (!string.IsNullOrEmpty(relativePath))
                        {
                            fileList[relativePath] = item;
                        }
                    }

                    if (!list.HasMore)
                    {
                        break;
                    }

                    list = await _client.Files.ListFolderContinueAsync(list.Cursor);
                }
            }
            catch (Dropbox.Api.ApiException<ListFolderError> ex)
            {
                if (ex.ErrorResponse.IsPath && ex.ErrorResponse.AsPath.Value.IsNotFound)
                {
                    return new Dictionary<string, Metadata>();
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return fileList;
        }


        public async Task DownloadNewFromDropboxToLocalAsync(Dictionary<string, FileInfo> localFiles, Dictionary<string, Metadata> dropboxFiles)
        {
            // ... (code inchangé, utilise _client) ...
            var downloadTasks = new List<Task>();
            var filesToDownload = dropboxFiles.Where(df => !localFiles.ContainsKey(df.Key)).ToList();
            int totalFiles = filesToDownload.Count;
            int filesProcessed = 0;

            if (totalFiles == 0)
            {
                return;
            }

            foreach (var dropboxFileEntry in filesToDownload)
            {
                string relativeDropboxPath = dropboxFileEntry.Key;
                Metadata dropboxFile = dropboxFileEntry.Value;
                string localPath = Path.Combine(_localFolderPath, relativeDropboxPath.Replace('/', Path.DirectorySeparatorChar));
                string dropboxDownloadPath = dropboxFile.PathDisplay;

                string localDir = Path.GetDirectoryName(localPath);
                if (!string.IsNullOrEmpty(localDir) && !Directory.Exists(localDir))
                {
                    try
                    {
                        Directory.CreateDirectory(localDir);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                await _downloadSemaphore.WaitAsync();
                downloadTasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        using (var response = await _client.Files.DownloadAsync(dropboxDownloadPath))
                        {
                            if (response != null)
                            {
                                using (var contentStream = await response.GetContentAsStreamAsync())
                                {
                                    using (var fileStream = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None))
                                    {
                                        await contentStream.CopyToAsync(fileStream);
                                    }
                                    Interlocked.Increment(ref filesProcessed);
                                    SynchronizationProgressChanged?.Invoke(this, new SynchronizationProgressEventArgs { FilesProcessed = filesProcessed, TotalFiles = totalFiles, OperationType = "Download" });
                                }
                            }
                        }
                    }
                    catch (Dropbox.Api.ApiException<DownloadError>)
                    {
                        // Handle API specific errors if needed, otherwise just catch
                    }
                    catch (Exception) // Catch other exceptions during download
                    {
                        // Log exception details if needed
                    }
                    finally
                    {
                        _downloadSemaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(downloadTasks);
        }

        public async Task UploadLocalToDropboxAsync(Dictionary<string, FileInfo> localFiles, Dictionary<string, Metadata> dropboxFiles)
        {
            // ... (code inchangé, utilise _client) ...
            var uploadTasks = new List<Task>();
            int totalFiles = localFiles.Count;
            int filesProcessed = 0;

            if (totalFiles == 0)
            {
                return;
            }

            foreach (var localFileEntry in localFiles)
            {
                string relativePath = localFileEntry.Key;
                FileInfo localFile = localFileEntry.Value;

                string dropboxFullPath;
                if (string.IsNullOrEmpty(_dropboxFolderPath))
                {
                    dropboxFullPath = "/" + relativePath;
                }
                else
                {
                    dropboxFullPath = $"{_dropboxFolderPath}/{relativePath}";
                }
                dropboxFullPath = dropboxFullPath.Replace("//", "/");

                if (!localFile.Exists)
                {
                    Interlocked.Decrement(ref totalFiles);
                    if (totalFiles > 0)
                    {
                        SynchronizationProgressChanged?.Invoke(this, new SynchronizationProgressEventArgs { FilesProcessed = filesProcessed, TotalFiles = totalFiles, OperationType = "Upload" });
                    }
                    continue;
                }

                await _uploadSemaphore.WaitAsync();
                uploadTasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        using (var stream = new FileStream(localFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var uploadArg = new UploadArg(
                                path: dropboxFullPath,
                                mode: WriteMode.Overwrite.Instance,
                                autorename: false,
                                clientModified: localFile.LastWriteTimeUtc
                            );

                            await _client.Files.UploadAsync(uploadArg, stream);
                            Interlocked.Increment(ref filesProcessed);
                            SynchronizationProgressChanged?.Invoke(this, new SynchronizationProgressEventArgs { FilesProcessed = filesProcessed, TotalFiles = totalFiles, OperationType = "Upload" });
                        }
                    }
                    catch (Dropbox.Api.ApiException<UploadError>)
                    {
                        // Handle API specific errors if needed
                    }
                    catch (System.IO.IOException) // Catch IO errors (file in use etc.)
                    {
                        // Handle IO errors
                    }
                    catch (Exception) // Catch other errors
                    {
                        // Log exception details if needed
                    }
                    finally
                    {
                        _uploadSemaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(uploadTasks);
            SynchronizationProgressChanged?.Invoke(this, new SynchronizationProgressEventArgs { FilesProcessed = filesProcessed, TotalFiles = totalFiles, OperationType = "Upload" });
        }

        public void LogFileLists(Dictionary<string, FileInfo> localFiles, Dictionary<string, Metadata> dropboxFiles)
        {
            // ... (code inchangé) ...
            // This method is for debugging and can be removed if not used.
            // The Console.WriteLine calls were already commented out.
        }
    }
}