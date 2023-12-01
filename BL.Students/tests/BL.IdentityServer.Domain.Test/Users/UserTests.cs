﻿using BL.IdentityServer.Domain.Test.DataAnnotations;
using BL.IdentityServer.Domain.Users;

using FluentAssertions;
using NUnit.Framework;

namespace BL.IdentityServer.Domain.Test.Users
{
    /// <summary>
    /// Testing DataAnnotations would be technically testing an external library,
    /// but I decided the leave the tests for demonstration purposes.
    /// </summary>
    public class UserTests
    {

        [Test]
        public void NotNullNameInitialization()
        {
            var user = new User();

            user.Name.Should().NotBeNull();
        }

        #region Email

        [Test]
        public void InvalidEmailTooLong()
        {
            var user = new User
            {
                Email = "testemailtestemailtestemailtestemailtestemailtesttest@gmail.com"
            };

            DataAnnotationsValidator
                .FindError(user, "Email", "maximum")
                .Should().NotBeNull();
        }

        [Test]
        public void InvalidEmailNoDomain()
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
        public void InvalidEmailMultipleSubDomains()
        {
            var user = new User
            {
                Email = "testemail@gmail@hotmail.com"
            };

            DataAnnotationsValidator
                .FindError(user, "Email", "Invalid")
                .Should().NotBeNull();
        }

        [Test]
        public void InvalidEmailCharacters()
        {
            var user = new User
            {
                Email = "test\r\nemail@gmail"
            };

            DataAnnotationsValidator
                .FindError(user, "Email", "Invalid")
                .Should().NotBeNull();
        }

        [Test]
        public void ValidEmailNoTLD()
        {
            var user = new User
            {
                Email = "testemail@gmail"
            };

            DataAnnotationsValidator
                .FindError(user, "Email", "Invalid")
                .Should().BeNull();
        }

        [Test]
        public void ValidEmailNonASCII()
        {
            var user = new User
            {
                Email = "test本email@gmail"
            };

            DataAnnotationsValidator
                .FindError(user, "Email")
                .Should().BeNull();
        }

        [Test]
        public void ValidEmail()
        {
            var user = new User
            {
                Email = "test-email@gmail.com"
            };

            DataAnnotationsValidator
                .FindError(user, "Email")
                .Should().BeNull();
        }

        #endregion

        #region Password

        [Test]
        public void RequiredPassword()
        {
            var user = new User
            {
                Name = "Fede D",
                Email = "testemail@gmail.com"
            };

            DataAnnotationsValidator
                .FindError(user, "Password", "required")
                .Should().NotBeNull();
        }

        [Test]
        public void InvalidPasswordLength()
        {
            var user = new User
            {
                Name = "Fede D",
                Email = "testemail@gmail.com",
                Password = "No1?"
            };

            user.IsValidPassword().Should().BeFalse();
        }

        [Test]
        public void InvalidPasswordMissingNonAlphanumeric()
        {
            var user = new User
            {
                Name = "Fede D",
                Email = "testemail@gmail.com",
                Password = "Abcdefg123"
            };

            user.IsValidPassword().Should().BeFalse();
        }

        [Test]
        public void InvalidPasswordMissingNumbers()
        {
            var user = new User
            {
                Name = "Fede D",
                Email = "testemail@gmail.com",
                Password = "Abcdefghij!#$%"
            };

            user.IsValidPassword().Should().BeFalse();
        }

        [Test]
        public void InvalidPasswordMissingUpper()
        {
            var user = new User
            {
                Name = "Fede D",
                Email = "testemail@gmail.com",
                Password = "abcdefghij!#$%"
            };

            user.IsValidPassword().Should().BeFalse();
        }

        [Test]
        public void ValidPasswordMissingLower()
        {
            var user = new User
            {
                Name = "Fede D",
                Email = "testemail@gmail.com",
                Password = "ABC1!#$%"
            };

            user.IsValidPassword().Should().BeTrue();
        }

        // TODO: Need to fix this and other chars not valid for passwords.
        // Can't send new lines in JSON, but we should not make assumptions on the client.
        [Test]
        public void InvalidPasswordChars()
        {
            var user = new User
            {
                Name = "Fede D",
                Email = "testemail@gmail.com",
                Password = "ABC1\r\n!#$%"
            };

            user.IsValidPassword().Should().BeFalse();
        }

        [Test]
        public void ValidPassword()
        {
            var user = new User
            {
                Name = "Fede D",
                Email = "testemail@gmail.com",
                Password = "Passw0rd?"
            };

            user.IsValidPassword().Should().BeTrue();
        }

        #endregion

    }
}