using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;


namespace BL.IdentityServer.Models;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>
{
}
