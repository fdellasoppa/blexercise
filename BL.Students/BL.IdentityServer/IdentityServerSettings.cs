using IdentityServer4.Models;

namespace BL.IdentityServer;

internal sealed class IdentityServerSettings
{

    public IReadOnlyCollection<ApiScope> ApiScopes { get; init; } = new List<ApiScope>();
    public IReadOnlyCollection<ApiResource> ApiResources { get; init; } = new List<ApiResource>();

    public IReadOnlyCollection<Client> Clients { get; init; } = new List<Client>();

    public static IReadOnlyCollection<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
        };
}