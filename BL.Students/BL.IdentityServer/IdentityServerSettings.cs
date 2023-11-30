using IdentityServer4.Models;

namespace BL.IdentityServer;

internal sealed class IdentityServerSettings
{

    public IList<ApiScope> ApiScopes { get; init; } = new List<ApiScope>();
    public IList<ApiResource> ApiResources { get; init; } = new List<ApiResource>();

    public IList<Client> Clients { get; init; } = new List<Client>();

    public static IReadOnlyCollection<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
        };
}