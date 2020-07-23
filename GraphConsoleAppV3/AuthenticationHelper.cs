using System;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace GraphConsoleAppV3
{
    internal class AuthenticationHelper
    {
        public static string TokenForUser;
        public static string TokenForApplication;

        /// <summary>
        /// Get Active Directory Client for Application.
        /// </summary>
        /// <returns>ActiveDirectoryClient for Application.</returns>
        public static ActiveDirectoryClient GetActiveDirectoryClientAsApplication()
        {
            Uri servicePointUri = new Uri(GlobalConstants.ResourceUrl);
            Uri serviceRoot = new Uri(servicePointUri, GlobalConstants.TenantId);
            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                async () => await AcquireTokenAsyncForApplication());
            return activeDirectoryClient;
        }

        /// <summary>
        /// Async task to acquire token for Application.
        /// </summary>
        /// <returns>Async Token for application.</returns>
        public static async Task<string> AcquireTokenAsyncForApplication()
        {
            return await GetTokenForApplication();
        }

        /// <summary>
        /// Get Token for Application.
        /// </summary>
        /// <returns>Token for application.</returns>
        public static async Task<string> GetTokenForApplication()
        {
            if (TokenForApplication == null)
            {
                AuthenticationContext authenticationContext = new AuthenticationContext(AppModeConstants.AuthString, false);
                // Config for OAuth client credentials 
                ClientCredential clientCred = new ClientCredential(GlobalConstants.ClientId,
                    AppModeConstants.ClientSecret);
                AuthenticationResult authenticationResult =
                    await authenticationContext.AcquireTokenAsync(GlobalConstants.ResourceUrl,
                        clientCred);
                TokenForApplication = authenticationResult.AccessToken;
            }
            return TokenForApplication;
        }

        /// <summary>
        /// Get Active Directory Client for User.
        /// </summary>
        /// <returns>ActiveDirectoryClient for User.</returns>
        public static ActiveDirectoryClient GetActiveDirectoryClientAsUser()
        {
            Uri servicePointUri = new Uri(GlobalConstants.ResourceUrl);
            Uri serviceRoot = new Uri(servicePointUri, GlobalConstants.TenantId);
            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                async () => await AcquireTokenAsyncForUser());
            return activeDirectoryClient;
        }

        /// <summary>
        /// Async task to acquire token for User.
        /// </summary>
        /// <returns>Token for user.</returns>
        public static async Task<string> AcquireTokenAsyncForUser()
        {
            return await GetTokenForUser();
        }

        /// <summary>
        /// Get Token for User.
        /// </summary>
        /// <returns>Token for user.</returns>
        public static async Task<string> GetTokenForUser()
        {
            try
            {
                if (TokenForUser == null)
                {
                    var redirectUri = new Uri("https://localhost");
                    AuthenticationContext authenticationContext = new AuthenticationContext(UserModeConstants.AuthString, false);
                    //AuthenticationResult userAuthnResult = await authenticationContext.AcquireTokenAsync(GlobalConstants.ResourceUrl,
                    //    GlobalConstants.ClientId, redirectUri, new PlatformParameters(PromptBehavior.RefreshSession));
                    var userCred = new UserPasswordCredential("nemes.laszlo@tsmpntsystems.onmicrosoft.com", "Azure@TSM001");
                    AuthenticationResult userAuthnResult = await authenticationContext.AcquireTokenAsync("https://tsmpntsystems.onmicrosoft.com/TodoListService", "3fca3592-2eea-43a8-8fad-f958a1b9f3c2", userCred);
                    //AuthenticationResult userAuthnResult = await authenticationContext.AcquireTokenAsync("https://tsmpntsystems.onmicrosoft.com/Boost", "a8d741e7-fd7d-4b2b-8f35-087866383bf0", userCred);
                    TokenForUser = userAuthnResult.AccessToken;
                    Console.WriteLine("\n Welcome " + userAuthnResult.UserInfo.GivenName + " " +
                                      userAuthnResult.UserInfo.FamilyName);
                }
                return TokenForUser;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
