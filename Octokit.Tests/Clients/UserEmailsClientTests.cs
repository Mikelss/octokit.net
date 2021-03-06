﻿using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Octokit.Tests.Clients
{
    public class UserEmailsClientTests
    {
        public class TheGetAllMethod
        {
            [Fact]
            public void GetsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new UserEmailsClient(connection);

                client.GetAll();

                connection.Received(1)
                    .GetAll<EmailAddress>(Arg.Is<Uri>(u => u.ToString() == "user/emails"));
            }
        }

        public class TheAddMethod
        {
            [Fact]
            public void PostsToCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new UserEmailsClient(connection);

                client.Add("octocat@github.com");

                connection.Received(1)
                    .Post<IReadOnlyList<EmailAddress>>(Arg.Is<Uri>(u => u.ToString() == "user/emails"), Arg.Any<string[]>());
            }

            [Fact]
            public void EnsuresNonNullArgument()
            {
                var client = new UserEmailsClient(Substitute.For<IApiConnection>());
                Assert.Throws<ArgumentNullException>(() => client.Add(null));
            }

            [Fact]
            public void EnsuresNoNullEmails()
            {
                var client = new UserEmailsClient(Substitute.For<IApiConnection>());
                Assert.Throws<ArgumentException>(() => client.Add("octokit@github.com", null));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void PostsToCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new UserEmailsClient(connection);

                client.Delete("octocat@github.com");

                connection.Received(1)
                    .Delete(Arg.Is<Uri>(u => u.ToString() == "user/emails"), Arg.Any<string[]>());
            }

            [Fact]
            public void EnsuresNonNullArgument()
            {
                var client = new UserEmailsClient(Substitute.For<IApiConnection>());
                Assert.Throws<ArgumentNullException>(() => client.Delete(null));
            }

            [Fact]
            public void EnsuresNoNullEmails()
            {
                var client = new UserEmailsClient(Substitute.For<IApiConnection>());
                Assert.Throws<ArgumentException>(() => client.Delete("octokit@github.com", null));
            }
        }

        public class TheCtor
        {
            [Fact]
            public void EnsuresArguments()
            {
                Assert.Throws<ArgumentNullException>(
                    () => new UserEmailsClient(null));
            }
        }
    }
}
