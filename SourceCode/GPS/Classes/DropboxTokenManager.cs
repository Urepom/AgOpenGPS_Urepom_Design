using Dropbox.Api;
using Dropbox.Api.Stone;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics; // Pour Console.WriteLine ou Debug.WriteLine
using System.Net; // Ajouté pour HttpStatusCode si non déjà présent

namespace AgOpenGPS // Assurez-vous que l'espace de noms correspond
{
    public class DropboxTokenManager
    {
        private readonly string _appKey;
        private readonly string _appSecret;
        private string _accessToken;
        private DateTime _accessTokenExpiry;
        private string _refreshToken;

        public event EventHandler<string> RefreshTokenAvailable;

        public DropboxTokenManager(string appKey, string appSecret)
        {
            _appKey = appKey;
            _appSecret = appSecret;
            _refreshToken = Properties.Settings.Default.UP_Dropbox_RefreshToken;
            _accessTokenExpiry = DateTime.MinValue; // Force rafraîchissement/obtention initiale
        }

        // Génère l'URL d'autorisation, prenant l'URI de redirection en paramètre
        // Génère l'URL d'autorisation pour l'utilisateur
        public string GenerateAuthorizationUrl(string redirectUri) // <-- Paramètre ajouté
        {
            Console.WriteLine("GenerateAuthorizationUrl method entered."); // Logging
            if (string.IsNullOrEmpty(redirectUri))
            {
                throw new ArgumentNullException(nameof(redirectUri), "L'URI de redirection ne peut pas être nulle ou vide.");
            }
            if (!Uri.TryCreate(redirectUri, UriKind.Absolute, out Uri validUri))
            {
                throw new ArgumentException($"L'URI de redirection spécifiée '{redirectUri}' n'a pas un format valide.", nameof(redirectUri));
            }

            // Générer un paramètre state sécurisé
            string state = Guid.NewGuid().ToString();
            Properties.Settings.Default.UP_Dropbox_OAuthState = state; // Stocker l'état pour vérifier le callback
            Properties.Settings.Default.Save();
            Console.WriteLine($"OAuth State generated and saved: {state}"); // Logging


            // Utilisation de DropboxOAuth2Helper pour générer l'URL
            var authorizeUrl = DropboxOAuth2Helper.GetAuthorizeUri(
                Dropbox.Api.OAuthResponseType.Code,
                _appKey,
                redirectUri, // <-- Utilise le paramètre
                state: state, // Passer le state
                              // *** AJOUTER LE PARAMÈTRE SUIVANT POUR DEMANDER UN JETON DE RAFRAÎCHISSEMENT ***
                tokenAccessType: Dropbox.Api.TokenAccessType.Offline // <-- Demander l'accès hors ligne
            );

            Console.WriteLine("Authorization URL generated: " + authorizeUrl.ToString()); // Logging
            Console.WriteLine("GenerateAuthorizationUrl method exited."); // Logging
            return authorizeUrl.ToString();
        }

        // Échange le code d'autorisation obtenu après redirection contre les jetons
        public async Task<bool> ExchangeCodeForTokensAsync(string authorizationCode, string state, string redirectUri) // <-- redirectUri ajouté ici aussi
        {
            Console.WriteLine("ExchangeCodeForTokensAsync method entered."); // Logging
            if (string.IsNullOrEmpty(authorizationCode))
            {
                Console.WriteLine("Error: Empty authorization code received."); // Logging
                return false;
            }
            if (string.IsNullOrEmpty(redirectUri))
            {
                Console.WriteLine("Error: redirectUri is null or empty."); // Logging
                throw new ArgumentNullException(nameof(redirectUri), "L'URI de redirection ne peut pas être nulle ou vide.");
            }


            // Récupérer l'état attendu
            string storedState = Properties.Settings.Default.UP_Dropbox_OAuthState;

            // Vérifier le paramètre state pour la sécurité
            if (string.IsNullOrEmpty(state) || state != storedState)
            {
                Console.WriteLine($"Security Error: OAuth State mismatch. Received: '{state}', Expected: '{storedState}'."); // Logging
                Properties.Settings.Default.UP_Dropbox_OAuthState = ""; // Effacer l'état stocké
                Properties.Settings.Default.Save();
                // Ne pas appeler UnlinkAccount() ici car aucun jeton n'est encore obtenu, et l'échange a échoué.
                return false; // Échec de la validation de l'état
            }

            // Effacer l'état utilisé une fois qu'il est vérifié et correspond
            Properties.Settings.Default.UP_Dropbox_OAuthState = "";
            Properties.Settings.Default.Save();
            Console.WriteLine("OAuth State verified and cleared."); // Logging


            try
            {
                Console.WriteLine($"Calling ProcessCodeFlowAsync with code, state, redirectUri."); // Logging
                // Utilisation de DropboxOAuth2Helper pour échanger le code
                var tokenResult = await DropboxOAuth2Helper.ProcessCodeFlowAsync(
                    authorizationCode,
                    _appKey,
                    _appSecret,
                    redirectUri // <-- Utilise le paramètre
                );
                Console.WriteLine("ProcessCodeFlowAsync completed."); // Logging


                // Utiliser ExpiresAt de l'objet OAuth2Response
                _accessToken = tokenResult.AccessToken;
                _accessTokenExpiry = tokenResult.ExpiresAt ?? DateTime.UtcNow.AddHours(4); // Utilise ExpiresAt, fallback si null
                Console.WriteLine($"AccessToken assigned. ExpiresAt: {_accessTokenExpiry.ToLocalTime()}"); // Logging


                // *** AJOUT DE LA LIGNE DE DÉBOGAGE ICI ***
                Console.WriteLine($"Debug: tokenResult.RefreshToken value is: {(string.IsNullOrEmpty(tokenResult.RefreshToken) ? "NULL or Empty" : "SET")}"); // Logging exact value


                _refreshToken = tokenResult.RefreshToken; // <-- Assignation
                if (_refreshToken == null)
                {
                    Properties.Settings.Default.UP_Dropbox_RefreshToken = "";

                }
                else
                {
                    Properties.Settings.Default.UP_Dropbox_RefreshToken = _refreshToken;
                }
                Properties.Settings.Default.Save(); // Sauvegarder les paramètres immédiatement
                Console.WriteLine("RefreshToken assigned and settings saved."); // Logging


                Console.WriteLine("Échange de code réussi. Compte lié."); // Logging
                // Notifier l'UI que le jeton de rafraîchissement est disponible
                RefreshTokenAvailable?.Invoke(this, _refreshToken); // <-- Utilise _refreshToken


                Console.WriteLine("ExchangeCodeForTokensAsync exited successfully."); // Logging
                return true; // Succès
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught in ExchangeCodeForTokensAsync: {ex}"); // Logging (log l'exception complète)
                // Gérer les erreurs pendant l'échange (ex: code invalide ou expiré)
                // En cas d'échec, s'assurer que les jetons potentiellement invalides sont effacés
                UnlinkAccount(); // Nettoyer si l'échange échoue (appelle RefreshTokenAvailable avec null)
                Console.WriteLine("ExchangeCodeForTokensAsync exited with error."); // Logging
                return false; // Échec
            }
        }
        private async Task<bool> RefreshAccessTokenAsync()
        {
            if (string.IsNullOrEmpty(_refreshToken))
            {
                Console.WriteLine("Rafraîchissement impossible : aucun jeton de rafraîchissement stocké.");
                return false;
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var requestUrl = "https://api.dropboxapi.com/oauth2/token";
                    var parameters = new Dictionary<string, string>
                    {
                        { "refresh_token", _refreshToken },
                        { "grant_type", "refresh_token" },
                        { "client_id", _appKey },
                        { "client_secret", _appSecret }
                    };

                    var encodedContent = new FormUrlEncodedContent(parameters);
                    var response = await httpClient.PostAsync(requestUrl, encodedContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Erreur HTTP lors du rafraîchissement du jeton : {response.StatusCode} - {errorResponse}");
                        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            Console.WriteLine("Jeton de rafraîchissement invalide ou expiré. Nécessite une ré-autorisation.");
                            UnlinkAccount();
                        }
                        return false;
                    }

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var tokenResult = JsonConvert.DeserializeObject<TokenRefreshResponse>(responseBody);

                    _accessToken = tokenResult.AccessToken;
                    _accessTokenExpiry = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResult.ExpiresIn);

                    if (!string.IsNullOrEmpty(tokenResult.RefreshToken) && tokenResult.RefreshToken != _refreshToken)
                    {
                        Console.WriteLine("Nouveau jeton de rafraîchissement obtenu.");
                        _refreshToken = tokenResult.RefreshToken;
                        if (_refreshToken == null)
                        {
                            Properties.Settings.Default.UP_Dropbox_RefreshToken = "";

                        }
                        else
                        {
                            Properties.Settings.Default.UP_Dropbox_RefreshToken = _refreshToken;
                        }
                        Properties.Settings.Default.Save();
                        RefreshTokenAvailable?.Invoke(this, _refreshToken);
                    }

                    Console.WriteLine("Jeton d'accès Dropbox rafraîchi avec succès. Expire à : " + _accessTokenExpiry.ToLocalTime());
                    return true;
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Erreur HttpRequest lors du rafraîchissement du jeton : {httpEx.Message}");
                return false;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Erreur JSON lors du rafraîchissement du jeton : {jsonEx.Message}");
                UnlinkAccount();
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur inattendue lors du rafraîchissement du jeton : {ex.Message}");
                UnlinkAccount();
                return false;
            }
        }

        // Classe d'aide pour désérialiser la réponse du point de terminaison /oauth2/token (pour le rafraîchissement)
        private class TokenRefreshResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; } // Temps restant avant expiration en secondes (JSON utilise expires_in)

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; } // Peut être null ou identique si Dropbox n'en émet pas de nouveau
        }


        // Fournit une instance valide de DropboxClient (cette méthode reste similaire)
        public async Task<DropboxClient> GetDropboxClientAsync()
        {
            if (!IsAccountLinked())
            {
                throw new InvalidOperationException("Le compte Dropbox n'est pas lié. Veuillez l'autoriser via le formulaire de configuration.");
            }

            bool needsRefresh = string.IsNullOrEmpty(_accessToken) ||
                                _accessTokenExpiry <= DateTime.UtcNow.AddMinutes(5); // Marge de 5 minutes

            if (needsRefresh)
            {
                Console.WriteLine("Le jeton d'accès est expiré ou sur le point de l'être. Tentative de rafraîchissement...");
                bool refreshSuccess = await RefreshAccessTokenAsync();

                if (!refreshSuccess)
                {
                    throw new InvalidOperationException("Le jeton d'accès Dropbox a expiré et n'a pas pu être rafraîchi. Votre accès a été révoqué ou le jeton de rafraîchissement est invalide. Veuillez relier votre compte.");
                }
            }

            if (string.IsNullOrEmpty(_accessToken))
            {
                throw new InvalidOperationException("Impossible d'obtenir un jeton d'accès Dropbox valide après rafraîchissement. Veuillez relier votre compte.");
            }

            Console.WriteLine("Fourniture d'un DropboxClient avec jeton d'accès valide.");
            return new DropboxClient(_accessToken);
        }

        public bool IsAccountLinked()
        {
            return !string.IsNullOrEmpty(_refreshToken);
        }

        public void UnlinkAccount()
        {
            Console.WriteLine("Déliement du compte Dropbox...");
            _accessToken = null;
            _accessTokenExpiry = DateTime.MinValue;
            _refreshToken = null;
            Properties.Settings.Default.UP_Dropbox_RefreshToken = "";
            Properties.Settings.Default.UP_Dropbox_OAuthState = ""; // Effacer l'état OAuth
            Properties.Settings.Default.Save();
            RefreshTokenAvailable?.Invoke(this, null);
        }
    }
}