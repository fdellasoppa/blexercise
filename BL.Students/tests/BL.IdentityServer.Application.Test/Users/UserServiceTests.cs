using BL.IdentityServer.Application.Users;
using BL.IdentityServer.Domain.Users;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BL.IdentityServer.Application.Test.Users
{
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
        }

        [Test]
        public void CreateDuplicateUser()
        {
            _userRepository.Setup(r => r.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new ApplicationUser()));
            var serv = new UserService(_userRepository.Object);

            var res = serv.CreateAsync(new User()).Result;

            res.DoesUserExist.Should().BeTrue();
        }

        [Test]
        public void CreateUserInvalidPassword()
        {
            _userRepository.Setup(r => r.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult((ApplicationUser)null));
            var serv = new UserService(_userRepository.Object);

            var res = serv.CreateAsync(new User() { Password = "1234" }).Result;

            res.IsPasswordOrNameInvalid.Should().BeTrue();
        }

        [Test]
        public void CreateUserInvalidName()
        {
            _userRepository.Setup(r => r.FindByEmailAsync(It.IsAny<string>()))
                .Returns(Task.FromResult((ApplicationUser)null));
            var serv = new UserService(_userRepository.Object);

            var res = serv.CreateAsync(new User() { Name = "Fede D" }).Result;

            res.IsPasswordOrNameInvalid.Should().BeTrue();
        }
    }
}