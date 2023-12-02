using BL.IdentityServer.Application.Users;
using BL.IdentityServer.Domain.Users;
using FluentAssertions;
using NUnit.Framework;

namespace BL.IdentityServer.Application.Test.Users
{
    public class UserServiceTests
    {
        [Test]
        public void CreateDuplicateUser()
        {
        //    var serv = new UserService();
        //// TODO: Need to mock repository calls
        //    var res = serv.CreateAsync(new User()).Result;

        //    res.DoesUserExist.Should().BeTrue();
        }
    }
}