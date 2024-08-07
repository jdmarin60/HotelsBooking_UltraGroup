using Duende.IdentityServer.Models;

namespace IdentityServerNETIdentity.ConfigExtensions
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes(string scope)
        {
            return new List<ApiScope>
            {
                new ApiScope(scope, "Access to Identity API") // Define ApiScope
            };
        }

        public static IEnumerable<ApiResource> GetApiResources(string apiResource, string scope)
        {
            return new List<ApiResource>
            {
                new ApiResource(apiResource, "Identity Service API")
                {
                    Scopes = { scope } // Scope name
                }
            };
        }

        public static IEnumerable<Client> GetClients(string clientId, string secret, string scope)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = clientId,
                    ClientSecrets = { new Secret(secret.Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new []
                    {
                        scope
                    } // Scope must match ApiScope below
                }
            };
        }
    }
}
