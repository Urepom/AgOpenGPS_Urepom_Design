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
        private readonly string _accessToken;
        private readonly DropboxClient _client;
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

        public DropboxSynchronizer(string localFolderPath, string dropboxFolderPath, string accessToken)
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

            _accessToken = accessToken;
            _client = new DropboxClient(_accessToken);
        }

        public Dictionary<string, FileInfo> GetLocalFiles(string path)
        {
            // S'assurer que le chemin local existe
            if (!Directory.Exists(path))
            {
                // Console.WriteLine($"[ERREUR] Le dossier local '{path}' n'existe pas."); // Log supprimé
                return new Dictionary<string, FileInfo>(); // Retourner un dictionnaire vide
            }
            try
            {
                return Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                                 .ToDictionary(f => f.Substring(path.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Replace('\\', '/'), // Chemin relatif avec '/'
                                               f => new FileInfo(f));
            }
            catch (UnauthorizedAccessException ex)
            {
                // Console.WriteLine($"[ERREUR] Accès refusé au dossier local '{path}'. Détails : {ex.Message}"); // Log supprimé
                // Gérer l'erreur comme approprié, par exemple, en informant l'utilisateur
                // Peut-être lancer une exception personnalisée ou retourner un dictionnaire vide
                return new Dictionary<string, FileInfo>();
            }
            catch (Exception ex) // Capturer d'autres erreurs potentielles
            {
                // Console.WriteLine($"[ERREUR] Erreur inattendue lors de l'accès au dossier local '{path}'. Détails : {ex.Message}"); // Log supprimé
                return new Dictionary<string, FileInfo>();
            }
        }


        // Méthode récursive pour lister les fichiers Dropbox
        // Méthode récursive pour lister les fichiers Dropbox AVEC GESTION DE LA PAGINATION
        public async Task<Dictionary<string, Metadata>> GetDropboxFilesAsync(string dropboxPathToList)
        {
            var fileList = new Dictionary<string, Metadata>();
            try
            {
                // Console.WriteLine($"[Dropbox API Call] ListFolderAsync initial avec le chemin : '{dropboxPathToList}' (Vide pour la racine), recursive: true"); // Log supprimé
                var list = await _client.Files.ListFolderAsync(dropboxPathToList, recursive: true); // Utiliser recursive: true

                while (true) // Boucle pour traiter les pages
                {
                    // Console.WriteLine($"Traitement de {list.Entries.Count} entrées de la page actuelle..."); // Log supprimé
                    foreach (var item in list.Entries.Where(i => i.IsFile))
                    {
                        // item.PathLower ou PathDisplay contient le chemin complet depuis la racine Dropbox
                        string fullPath = item.PathDisplay; // ou PathLower pour la comparaison insensible à la casse
                        string relativePath = fullPath;

                        // Calculer le chemin relatif par rapport au _dropboxFolderPath spécifié
                        if (!string.IsNullOrEmpty(_dropboxFolderPath))
                        {
                            if (fullPath.StartsWith(_dropboxFolderPath + "/", StringComparison.OrdinalIgnoreCase))
                            {
                                relativePath = fullPath.Substring(_dropboxFolderPath.Length + 1);
                            }
                            else if (fullPath.Equals(_dropboxFolderPath, StringComparison.OrdinalIgnoreCase))
                            {
                                continue; // Ignorer l'entrée qui est le dossier lui-même
                            }
                            else
                            {
                                // Le fichier n'est pas dans le sous-dossier attendu OU _dropboxFolderPath est la racine et le fichier est à la racine
                                if (_dropboxFolderPath == "" && !fullPath.Contains("/")) // Cas racine
                                {
                                    relativePath = fullPath.TrimStart('/');
                                }
                                else // Fichier hors du chemin spécifié (si _dropboxFolderPath n'est pas la racine)
                                {
                                    // Console.WriteLine($"[DEBUG] Fichier ignoré car hors du chemin spécifié: {fullPath} (Attendu dans ou sous {_dropboxFolderPath})"); // Log supprimé
                                    continue;
                                }
                            }
                        }
                        else // Si _dropboxFolderPath est vide (racine)
                        {
                            // Le chemin relatif est le chemin complet sans le '/' initial
                            relativePath = fullPath.TrimStart('/');
                        }

                        // Utiliser le chemin relatif comme clé
                        if (!string.IsNullOrEmpty(relativePath)) // S'assurer que la clé n'est pas vide
                        {
                            // Attention: Si des chemins diffèrent uniquement par la casse et qu'on utilise PathDisplay,
                            // on pourrait écraser une entrée. Utiliser PathLower comme clé si l'insensibilité à la casse est requise.
                            // Pour rester cohérent avec le reste du code qui semble sensible à la casse (chemins Windows), on garde PathDisplay.
                            fileList[relativePath] = item;
                            // Console.WriteLine($"[DEBUG] Fichier Dropbox trouvé: Clé='{relativePath}', Chemin complet='{fullPath}'"); // Log supprimé
                        }
                    }

                    // Vérifier s'il y a d'autres pages de résultats
                    if (!list.HasMore)
                    {
                        // Console.WriteLine("Fin du listage Dropbox, pas d'autres pages."); // Log supprimé
                        break; // Sortir de la boucle while
                    }

                    // Récupérer la page suivante
                    // Console.WriteLine("[Dropbox API Call] ListFolderContinueAsync pour la page suivante..."); // Log supprimé
                    list = await _client.Files.ListFolderContinueAsync(list.Cursor);
                } // Fin de la boucle while(true)

            }
            catch (Dropbox.Api.ApiException<ListFolderError> ex)
            {
                // Console.WriteLine($"[ERREUR API Dropbox] Échec de ListFolderAsync/Continue pour '{dropboxPathToList}': {ex.ErrorResponse}"); // Log supprimé
                if (ex.ErrorResponse.IsPath && ex.ErrorResponse.AsPath.Value.IsNotFound)
                {
                    // Console.WriteLine($"[INFO] Le dossier Dropbox spécifié '{dropboxPathToList}' n'existe pas."); // Log supprimé
                    return new Dictionary<string, Metadata>();
                }
                throw;
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"[ERREUR INATTENDUE] lors de GetDropboxFilesAsync pour '{dropboxPathToList}': {ex.Message}"); // Log supprimé
                throw;
            }
            // Console.WriteLine($"Listage Dropbox terminé. Total fichiers trouvés dans '{dropboxPathToList}': {fileList.Count}"); // Log supprimé
            return fileList;
        }


        public async Task DownloadNewFromDropboxToLocalAsync(Dictionary<string, FileInfo> localFiles, Dictionary<string, Metadata> dropboxFiles)
        {
            // Console.WriteLine("Téléchargement de Dropbox vers le local (si inexistant localement) en parallèle..."); // Log supprimé
            var downloadTasks = new List<Task>();
            // Filtrer les fichiers Dropbox qui n'ont pas de clé correspondante dans localFiles
            var filesToDownload = dropboxFiles.Where(df => !localFiles.ContainsKey(df.Key)).ToList();
            int totalFiles = filesToDownload.Count;
            int filesProcessed = 0;

            if (totalFiles == 0)
            {
                // Console.WriteLine("Aucun nouveau fichier à télécharger depuis Dropbox."); // Log supprimé
                return; // Sortir si rien à faire
            }

            foreach (var dropboxFileEntry in filesToDownload)
            {
                string relativeDropboxPath = dropboxFileEntry.Key; // C'est le chemin relatif
                Metadata dropboxFile = dropboxFileEntry.Value; // Contient PathDisplay (chemin complet)

                // Construction du chemin local
                string localPath = Path.Combine(_localFolderPath, relativeDropboxPath.Replace('/', Path.DirectorySeparatorChar));

                // Utiliser le chemin complet de Dropbox (PathDisplay) pour le téléchargement
                string dropboxDownloadPath = dropboxFile.PathDisplay; // Utiliser le chemin absolu fourni par l'API

                // Console.WriteLine($"[DOWNLOAD] Fichier à télécharger : '{dropboxFile.Name}', Chemin relatif clé : '{relativeDropboxPath}'"); // Log supprimé
                // Console.WriteLine($"[DOWNLOAD] Chemin Dropbox (pour DownloadAsync) : '{dropboxDownloadPath}'"); // Log supprimé
                // Console.WriteLine($"[DOWNLOAD] Chemin local de destination : '{localPath}'"); // Log supprimé

                string localDir = Path.GetDirectoryName(localPath);
                if (!string.IsNullOrEmpty(localDir) && !Directory.Exists(localDir))
                {
                    try
                    {
                        Directory.CreateDirectory(localDir);
                        // Console.WriteLine($"[DOWNLOAD] Création du répertoire local : '{localDir}'"); // Log supprimé
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine($"[ERREUR] Impossible de créer le répertoire local '{localDir}'. Erreur: {ex.Message}"); // Log supprimé
                        continue; // Passer au fichier suivant si le dossier ne peut être créé
                    }
                }

                await _downloadSemaphore.WaitAsync();
                downloadTasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        // Console.WriteLine($"[Dropbox API Call] DownloadAsync avec le chemin : '{dropboxDownloadPath}'"); // Log supprimé
                        using (var response = await _client.Files.DownloadAsync(dropboxDownloadPath))
                        {
                            if (response != null)
                            {
                                using (var contentStream = await response.GetContentAsStreamAsync())
                                {
                                    using (var fileStream = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None)) // Utiliser FileMode.Create pour écraser si jamais il existe (ne devrait pas avec la logique actuelle)
                                    {
                                        await contentStream.CopyToAsync(fileStream);
                                    }
                                    Interlocked.Increment(ref filesProcessed);
                                    SynchronizationProgressChanged?.Invoke(this, new SynchronizationProgressEventArgs { FilesProcessed = filesProcessed, TotalFiles = totalFiles, OperationType = "Download" });
                                    // Console.WriteLine($"[DOWNLOAD] Téléchargé : '{dropboxFile.Name}' vers '{localPath}'"); // Log supprimé
                                }
                            }
                            else
                            {
                                // Console.WriteLine($"[ERREUR DOWNLOAD] Réponse de téléchargement nulle pour : '{dropboxDownloadPath}'"); // Log supprimé
                            }
                        }
                    }
                    catch (Dropbox.Api.ApiException<DownloadError> ex)
                    {
                        // Console.WriteLine($"[ERREUR API DOWNLOAD] Échec du téléchargement pour '{dropboxDownloadPath}'. Erreur Dropbox: {ex.ErrorResponse}"); // Log supprimé
                    }
                    catch (Exception ex)
                    {
                        // Console.WriteLine($"[ERREUR INATTENDUE DOWNLOAD] Message : {ex.Message} pour le fichier : '{dropboxDownloadPath}'"); // Log supprimé
                        // Log ex.ToString() pour plus de détails si nécessaire
                    }
                    finally
                    {
                        _downloadSemaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(downloadTasks);
            // Console.WriteLine("Téléchargement depuis Dropbox terminé."); // Log supprimé
        }

        // *** MÉTHODE MISE À JOUR ***
        public async Task UploadLocalToDropboxAsync(Dictionary<string, FileInfo> localFiles, Dictionary<string, Metadata> dropboxFiles)
        {
            // Console.WriteLine("Téléversement du local vers Dropbox (remplacement si existant) en parallèle..."); // Log supprimé
            var uploadTasks = new List<Task>();
            // Le nombre total de fichiers à traiter est maintenant TOUS les fichiers locaux
            int totalFiles = localFiles.Count;
            int filesProcessed = 0;

            if (totalFiles == 0)
            {
                // Console.WriteLine("Aucun fichier local à téléverser."); // Log supprimé
                return; // Sortir si rien à faire
            }

            // Itérer sur TOUS les fichiers locaux
            foreach (var localFileEntry in localFiles)
            {
                string relativePath = localFileEntry.Key; // Chemin relatif avec '/'
                FileInfo localFile = localFileEntry.Value;

                // Construire le chemin complet Dropbox en utilisant le chemin relatif
                // Gérer le cas où _dropboxFolderPath est vide (racine)
                string dropboxFullPath;
                if (string.IsNullOrEmpty(_dropboxFolderPath))
                {
                    dropboxFullPath = "/" + relativePath;
                }
                else
                {
                    // _dropboxFolderPath commence déjà par '/' (sauf s'il était vide)
                    dropboxFullPath = $"{_dropboxFolderPath}/{relativePath}";
                }
                // Nettoyage final pour éviter les "//" si relativePath commençait par "/" (ne devrait pas)
                dropboxFullPath = dropboxFullPath.Replace("//", "/");


                // Console.WriteLine($"[UPLOAD] Nom du fichier local : '{localFile.Name}', Chemin local : '{localFile.FullName}'"); // Log supprimé
                // Console.WriteLine($"[UPLOAD] Chemin Dropbox de destination : '{dropboxFullPath}'"); // Log supprimé

                // Vérifier si le fichier local est accessible avant de continuer
                if (!localFile.Exists)
                {
                    // Console.WriteLine($"[AVERTISSEMENT UPLOAD] Le fichier local '{localFile.FullName}' n'existe plus. Ignoré."); // Log supprimé
                    // Décrémenter totalFiles car on ne le traitera pas
                    Interlocked.Decrement(ref totalFiles);
                    // Mettre à jour immédiatement la barre de progression si nécessaire, ou laisser la valeur max telle quelle
                    if (totalFiles > 0) // Éviter la division par zéro
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
                        // Utiliser FileShare.ReadWrite peut aider à éviter les problèmes de verrouillage
                        using (var stream = new FileStream(localFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            // Console.WriteLine($"[Dropbox API Call] UploadAsync vers le chemin : '{dropboxFullPath}' avec remplacement"); // Log supprimé

                            // CORRECTION ICI : Passer clientModified DANS le constructeur
                            var uploadArg = new UploadArg(
                                path: dropboxFullPath,             // Le chemin sur Dropbox
                                mode: WriteMode.Overwrite.Instance,    // Mode écrasement
                                autorename: false,                 // Ne pas renommer automatiquement
                                clientModified: localFile.LastWriteTimeUtc // Passer la date de modification ici
                                                                           // Les autres paramètres optionnels (mute, propertyGroups, etc.) utilisent leur valeur par défaut
                            );

                            // Supprimez ou commentez cette ligne qui causait l'erreur :
                            // uploadArg.ClientModified = localFile.LastWriteTimeUtc; // ERREUR: Accesseur Set non accessible

                            await _client.Files.UploadAsync(uploadArg, stream);
                            Interlocked.Increment(ref filesProcessed);
                            // Mettre à jour la progression après chaque succès
                            SynchronizationProgressChanged?.Invoke(this, new SynchronizationProgressEventArgs { FilesProcessed = filesProcessed, TotalFiles = totalFiles, OperationType = "Upload" });
                            // Console.WriteLine($"[UPLOAD] Téléversé : '{localFile.Name}' vers '{dropboxFullPath}' (remplacé si existant)"); // Log supprimé
                        }
                    }
                    catch (Dropbox.Api.ApiException<UploadError> ex) // Gérer les erreurs d'API Dropbox spécifiques
                    {
                        // Console.WriteLine($"[ERREUR API UPLOAD] Échec pour '{dropboxFullPath}'. Erreur Dropbox: {ex.ErrorResponse}"); // Log supprimé
                        // Peut-être logguer ex.ToString() pour tous les détails
                    }
                    catch (System.IO.IOException ex) // Attraper les erreurs IO (fichier utilisé, etc.)
                    {
                        // Console.WriteLine($"[ERREUR IO UPLOAD] Impossible d'ouvrir le fichier local '{localFile.FullName}'. Est-il utilisé par une autre application? Erreur: {ex.Message}"); // Log supprimé
                    }
                    catch (Exception ex) // Gérer les autres erreurs
                    {
                        // Console.WriteLine($"[ERREUR UPLOAD] Échec du téléversement pour : '{localFile.FullName}' vers '{dropboxFullPath}'. Erreur: {ex.Message}"); // Log supprimé
                        // Pour un débogage plus approfondi, logguez l'exception complète : Console.WriteLine(ex.ToString());
                    }
                    finally
                    {
                        _uploadSemaphore.Release();
                    }
                }));
            } // Fin de la boucle foreach

            await Task.WhenAll(uploadTasks);
            // Console.WriteLine("Téléversement vers Dropbox terminé."); // Log supprimé
            // Assurer une mise à jour finale de la barre de progression
            SynchronizationProgressChanged?.Invoke(this, new SynchronizationProgressEventArgs { FilesProcessed = filesProcessed, TotalFiles = totalFiles, OperationType = "Upload" });
        } // Fin de la méthode UploadLocalToDropboxAsync

        // Méthode de log pour débogage (inchangée)
        // Cette méthode est conservée mais n'est plus appelée dans les méthodes de synchronisation si vous avez supprimé les appels.
        // Vous pouvez la supprimer complètement si elle n'est plus utilisée ailleurs.
        public void LogFileLists(Dictionary<string, FileInfo> localFiles, Dictionary<string, Metadata> dropboxFiles)
        {
            // Console.WriteLine($"\n--- Fichiers Locaux ({localFiles.Count}) dans '{_localFolderPath}' ---"); // Log supprimé
            foreach (var kvp in localFiles.OrderBy(f => f.Key)) // Tri pour comparaison facile
            {
                // Console.WriteLine($"  Local: '{kvp.Key}' (Modifié: {kvp.Value.LastWriteTimeUtc})"); // Log supprimé
            }

            // Console.WriteLine($"\n--- Fichiers Dropbox ({dropboxFiles.Count}) dans '{_dropboxFolderPath}' ---"); // Log supprimé
            foreach (var kvp in dropboxFiles.OrderBy(f => f.Key)) // Tri pour comparaison facile
            {
                // Afficher la date de modification serveur si c'est un fichier
                var fileMetadata = kvp.Value.AsFile; // Tente de caster en FileMetadata
                string serverModified = fileMetadata != null ? fileMetadata.ServerModified.ToString() : "N/A (Pas un fichier?)";
                // Console.WriteLine($"  Dropbox: '{kvp.Key}' (Modifié Serveur: {serverModified}, Chemin complet: {kvp.Value.PathDisplay})"); // Log supprimé
            }
            // Console.WriteLine("--- Fin des listes ---"); // Log supprimé
        }
    }
}
