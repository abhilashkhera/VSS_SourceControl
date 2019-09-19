using Microsoft.Graph;  
using Microsoft.Identity.Client;  
using System;  
using System.Configuration;  
using System.Net.Http.Headers;  
using System.Threading.Tasks; 


static async Task < string > GetTokenAsync(PublicClientApplication clientApp) {  
        //need to pass scope of activity to get token  
        string[] Scopes = {“  
            User.Read "};  
            string token = null;  
            AuthenticationResult authResult = await clientApp.AcquireTokenAsync(Scopes);  
            token = authResult.AccessToken;  
            return token;  
        }  PublicClientApplication clientApp = new PublicClientApplication(ConfigurationManager.AppSettings["clientId"].ToString());  
GraphServiceClient graphClient = new GraphServiceClient("https://graph.microsoft.com/v1.0", new DelegateAuthenticationProvider(async (requestMessage) => {  
    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", await GetTokenAsync(clientApp));  
}));  
