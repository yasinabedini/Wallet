using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace Identity_Provider
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope{Name="walletapi",DisplayName="Wallet"}
            };

        public static IEnumerable<Client> Clients => new Client[]
        {
        //       new Client
        //        {
        //            ClientName = "Project.Client",
        //            ClientId  = "Project.Client",
        //            ClientSecrets = new List<Secret>
        //            {
        //                new Secret("Project.Client".ToSha256())
        //            },
        //            AllowedGrantTypes=GrantTypes.Code,
        //             RedirectUris={ "https://localhost:7242/signin-oidc" },
        //           PostLogoutRedirectUris={ "https://localhost:7242/signout-callback-oidc" },
        //           AllowedScopes = new List<string>
        //           {
        //               IdentityServerConstants.StandardScopes.OpenId,
        //               IdentityServerConstants.StandardScopes.Profile,
        //               "Project.Api",
        //           },
        //           AllowOfflineAccess = true,
        //        }
        };
    }
}