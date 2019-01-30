using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Test;

namespace IdentityServerCenter
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "My Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //OAuth 2.0  用IdentityServer实现的客户端模式（client credentials）
                new Client()
                {
                     ClientId = "client",
                     AllowedGrantTypes = GrantTypes.ClientCredentials,

                     ClientSecrets = { new Secret("secret".Sha256()) },

                     AllowedScopes = {"api"}
                },
                //OAuth 2.0  用IdentityServer实现的密码模式（resource owner password credentials）
                new Client()
                {
                     ClientId = "pwdClient",
                     AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                     ClientSecrets = { new Secret("secret".Sha256()) },

                     AllowedScopes = {"api"}
                }
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                     Username = "test",
                      Password = "123456"
                }
            };
        }
    }
}
