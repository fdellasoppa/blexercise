using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;


namespace BL.IdentityServer.Domain.Users;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>
{
}
