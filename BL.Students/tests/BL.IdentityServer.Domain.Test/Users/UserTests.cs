using BL.IdentityServer.Domain.Test.DataAnnotations;
using BL.IdentityServer.Domain.Users;

using FluentAssertions;
using NUnit.Framework;

namespace BL.IdentityServer.Domain.Test.Users
{
    public class UserTests
    {

        [Test]
        public void NotNullNameInitialization()
        {
            var user = new User();

            user.Name.Should().NotBeNull();
        }

        [Test]
        public void InvalidEmail()
        {
            var user = new User
            {
                Email = "testemail"
            };

            DataAnnotationsValidator
                .FindError(user, "Email", "Invalid")
                .Should().NotBeNull();
        }

        [Test]
        public void RequiredPassword()
        {
            var user = new User();

            DataAnnotationsValidator
                .FindError(user, "Password", "required")
                .Should().NotBeNull();
        }

    }
}