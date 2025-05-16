using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json; // Nécessite le package NuGet Newtonsoft.Json
using System.Collections.Generic;

namespace AgOpenGPS // Assurez-vous que l'espace de noms correspond
{
    // Classe pour interagir avec l'API REST de Syncthing
    public class SyncthingApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _syncthingApiUrl;
        private readonly string _apiKey;

        // Constructeur
        public SyncthingApiClient(string apiUrl, string apiKey)
        {
            if (string.IsNullOrEmpty(apiUrl))
                throw new ArgumentNullException(nameof(apiUrl), "L'URL de l'API Syncthing ne peut pas être nulle ou vide.");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey), "La clé API Syncthing ne peut pas être nulle ou vide.");

            _syncthingApiUrl = apiUrl.TrimEnd('/'); // Supprime le slash final si présent
            _apiKey = apiKey;

            _httpClient = new HttpClient();
            // Ajoute l'en-tête X-API-Key requis par Syncthing
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", _apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Méthode générique pour faire des appels GET à l'API
        private async Task<T> GetAsync<T>(string endpoint)
        {
            string requestUrl = $"{_syncthingApiUrl}/{endpoint.TrimStart('/')}"; // Assure que l'endpoint commence par un slash

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                // Vérifie si la réponse est réussie (statut 2xx)
                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Erreur HTTP lors de l'appel GET à {requestUrl} : {response.StatusCode} - {errorContent}");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();
                // Désérialise la réponse JSON dans le type spécifié T
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            catch (HttpRequestException httpEx)
            {
                // Gère les erreurs liées aux requêtes HTTP (connexion, etc.)
                throw new Exception($"Erreur de requête HTTP vers l'API Syncthing : {httpEx.Message}", httpEx);
            }
            catch (JsonException jsonEx)
            {
                // Gère les erreurs de désérialisation JSON
                throw new Exception($"Erreur de désérialisation de la réponse de l'API Syncthing : {jsonEx.Message}", jsonEx);
            }
            catch (Exception ex)
            {
                // Gère les autres exceptions inattendues
                throw new Exception($"Une erreur inattendue s'est produite lors de l'appel à l'API Syncthing : {ex.Message}", ex);
            }
        }

        // Méthode générique pour faire des appels POST à l'API avec réponse
        private async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            string requestUrl = $"{_syncthingApiUrl}/{endpoint.TrimStart('/')}";

            try
            {
                string jsonContent = JsonConvert.SerializeObject(data);
                StringContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Erreur HTTP lors de l'appel POST à {requestUrl} : {response.StatusCode} - {errorContent}");
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();
                // Désérialise la réponse JSON
                return JsonConvert.DeserializeObject<TResponse>(jsonResponse);
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"Erreur de requête HTTP vers l'API Syncthing : {httpEx.Message}", httpEx);
            }
            catch (JsonException jsonEx)
            {
                throw new Exception($"Erreur de désérialisation de la réponse de l'API Syncthing : {jsonEx.Message}", jsonEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Une erreur inattendue s'est produite lors de l'appel à l'API Syncthing : {ex.Message}", ex);
            }
        }

        // Méthode générique pour faire des appels POST sans réponse spécifique attendue
        private async Task PostAsync<TRequest>(string endpoint, TRequest data)
        {
            string requestUrl = $"{_syncthingApiUrl}/{endpoint.TrimStart('/')}";

            try
            {
                string jsonContent = JsonConvert.SerializeObject(data);
                StringContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(requestUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Erreur HTTP lors de l'appel POST à {requestUrl} : {response.StatusCode} - {errorContent}");
                }
                // Pas de désérialisation de réponse spécifique ici
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"Erreur de requête HTTP vers l'API Syncthing : {httpEx.Message}", httpEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Une erreur inattendue s'est produite lors de l'appel à l'API Syncthing : {ex.Message}", ex);
            }
        }


        // --- Méthodes spécifiques pour l'API Syncthing ---

        // Vérifie la connexion à l'API et obtient des informations de base
        public async Task<SystemInfo> GetSystemInfoAsync()
        {
            // L'endpoint /rest/system/status est plus complet pour un check de santé
            return await GetAsync<SystemInfo>("/rest/system/status");
        }

        // Obtient la liste des dossiers partagés
        public async Task<List<Folder>> GetFoldersAsync()
        {
            // L'endpoint /rest/config/folders retourne la configuration des dossiers
            // Note: L'endpoint /rest/config retourne la config complète, mais /rest/config/folders est plus direct
            return await GetAsync<List<Folder>>("/rest/config/folders");
        }

        // Obtient la liste des appareils connectés
        public async Task<List<Device>> GetDevicesAsync()
        {
            // L'endpoint /rest/config/devices retourne la configuration des appareils
            // Note: L'endpoint /rest/config retourne la config complète, mais /rest/config/devices est plus direct
            return await GetAsync<List<Device>>("/rest/config/devices");
        }

        // Ajoute un nouveau dossier partagé en utilisant le bon endpoint POST /rest/config/folders
        public async Task AddFolderAsync(Folder newFolder)
        {
            // Utilise POST sur /rest/config/folders avec le nouvel objet Folder
            // La documentation indique que POST sur /rest/config/folders prend un seul objet Folder
            await PostAsync("/rest/config/folders", newFolder);
        }

        // Ajoute un nouvel appareil en utilisant le bon endpoint POST /rest/config/devices
        public async Task AddDeviceAsync(Device newDevice)
        {
            // Utilise POST sur /rest/config/devices avec le nouvel objet Device
            // La documentation indique que POST sur /rest/config/devices prend un seul objet Device
            await PostAsync("/rest/config/devices", newDevice);
        }

        // Redémarre Syncthing (nécessaire après ajout/modification de dossiers/appareils)
        public async Task RestartSyncthingAsync()
        {
            // L'endpoint /rest/system/restart
            await PostAsync("/rest/system/restart", new { }); // POST avec un corps vide
        }

        // Obtient le statut d'un dossier (synchronisé, en cours, etc.)
        public async Task<FolderStatus> GetFolderStatusAsync(string folderId)
        {
            // L'endpoint /rest/db/status?folder=<folderId>
            return await GetAsync<FolderStatus>($"/rest/db/status?folder={Uri.EscapeDataString(folderId)}");
        }

        // Obtient le statut des appareils (connecté, déconnecté, etc.)
        // Note: L'API ne fournit pas un endpoint pour le statut de TOUS les appareils en une fois facilement.
        // Il faut souvent interroger /rest/connections ou /rest/system/connections
        public async Task<Connections> GetConnectionsAsync()
        {
            // L'endpoint /rest/system/connections
            return await GetAsync<Connections>("/rest/system/connections");
        }


        // Implémentation de IDisposable pour libérer les ressources HttpClient
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }

    // --- Classes pour la structure des réponses de l'API Syncthing ---
    // Ces classes doivent correspondre à la structure JSON retournée par l'API.
    // Vous devrez peut-être les ajuster en fonction de la version de l'API Syncthing.

    // Exemple de structure pour /rest/system/status
    public class SystemInfo
    {
        [JsonProperty("myID")]
        public string MyID { get; set; }

        [JsonProperty("discoveryEnabled")]
        public bool DiscoveryEnabled { get; set; }

        // Ajoutez d'autres propriétés pertinentes de l'endpoint /rest/system/status
    }

    // Exemple de structure pour /rest/config (utilisé pour GET, mais pas pour POST direct de la config complète)
    public class SyncthingConfig
    {
        [JsonProperty("folders")]
        public List<Folder> Folders { get; set; }

        [JsonProperty("devices")]
        public List<Device> Devices { get; set; }

        // Ajoutez d'autres sections de configuration si nécessaire
    }

    // Représente un dossier partagé dans la configuration Syncthing
    public class Folder
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } // "sendreceive", "sendonly", "receiveonly"

        [JsonProperty("devices")]
        public List<FolderDevice> Devices { get; set; } // Appareils connectés à ce dossier

        // Ajoutez d'autres propriétés de dossier pertinentes
    }

    // Représente un appareil associé à un dossier
    public class FolderDevice
    {
        [JsonProperty("deviceID")]
        public string DeviceID { get; set; }
        // Ajoutez d'autres propriétés si nécessaire (ex: introducedBy)
    }


    // Représente un appareil distant dans la configuration Syncthing
    public class Device
    {
        [JsonProperty("deviceID")]
        public string DeviceID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("addresses")]
        public List<string> Addresses { get; set; } // Liste des adresses de l'appareil

        // Ajoutez d'autres propriétés d'appareil pertinentes
    }

    // Exemple de structure pour /rest/db/status
    public class FolderStatus
    {
        [JsonProperty("state")]
        public string State { get; set; } // "idle", "scanning", "syncing", "cleaning", "indexing", "limitWaiting"

        [JsonProperty("pullErrors")]
        public int PullErrors { get; set; }

        [JsonProperty("globalBytes")]
        public long GlobalBytes { get; set; }

        [JsonProperty("localBytes")]
        public long LocalBytes { get; set; }

        [JsonProperty("globalFiles")]
        public int GlobalFiles { get; set; }

        [JsonProperty("localFiles")]
        public int LocalFiles { get; set; }

        [JsonProperty("needBytes")]
        public long NeedBytes { get; set; }

        [JsonProperty("needFiles")]
        public int NeedFiles { get; set; }

        // Ajoutez d'autres propriétés de statut de dossier pertinentes
    }

    // Exemple de structure pour /rest/system/connections
    public class Connections
    {
        [JsonProperty("connections")]
        public Dictionary<string, ConnectionDetails> Details { get; set; } // Clé: DeviceID, Valeur: Détails de connexion
    }

    // Détails de connexion pour un appareil
    public class ConnectionDetails
    {
        [JsonProperty("connected")]
        public bool Connected { get; set; }

        [JsonProperty("clientVersion")]
        public string ClientVersion { get; set; }

        // Ajoutez d'autres propriétés de connexion pertinentes
    }
}
