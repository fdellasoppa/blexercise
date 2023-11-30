using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;


namespace BL.IdentityServer.Domain.Roles;

[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<Guid>
{
}
