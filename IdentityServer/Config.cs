using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{


    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> result = new List<ApiResource>();

            result.Add(new ApiResource("resource1"));

            return result;
        }

        public static IEnumerable<Client> GetApiClients()
        {
            List<Client> result = new List<Client>();

            result.Add
            (
                new Client()
                {
                    ClientId = "client1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "resource1" },
                    ClientSecrets = { new Secret("secret1".Sha256()) }
                }
            );

            return result;
        }
    }

}
