using Duende.IdentityServer.EntityFramework.Entities;
using IdentityServerNETIdentity.Helpers;
using IdentityServerNETIdentity.Models;
using IdentityServerNETIdentity.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace IdentityServerNETIdentity.Utils
{
    public class GenerateToken
    {
        static HttpClient client = new HttpClient();
        public async Task<PetitionResponse> Token(string url, string client_id, string secret_id, string scope)
        {
            var client = new RestClient($"{url}/connect/token");
            var request = new RestRequest()
                .AddHeader("Content-Type", "application/x-www-form-urlencoded")
                .AddParameter("grant_type", "client_credentials")
                .AddParameter("client_id", client_id)
                .AddParameter("client_secret", secret_id)
                .AddParameter("scope", scope);  

            var response = await client.PostAsync(request);
            
            if (!response.IsSuccessful)
                throw new Exception($"Error en la petición {response.ErrorMessage} con código de error {response.StatusCode}");

             //= JObject.Parse();
            ConvertToken token = JsonConvert.DeserializeObject<ConvertToken>(response.Content);

            return AnswerResponse.Answer(true, "Token Generado exitosamente", token);
        }
    }
}
