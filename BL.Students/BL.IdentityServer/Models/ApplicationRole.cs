using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;


namespace BL.IdentityServer.Models;

[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<Guid>
{
}
