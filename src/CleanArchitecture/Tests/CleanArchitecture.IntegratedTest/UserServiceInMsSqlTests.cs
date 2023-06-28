using Api.Users;
using Common.Factories;
using Common;
using Grpc.Net.Client;
using Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace CleanArchitecture.IntegratedTest;

public class UserServiceInMsSqlTests : TestBase<TestMsSqlFactory<Program, ApplicationDbContext>>
{
    private readonly GrpcChannel _channel;
    public UserServiceInMsSqlTests(TestMsSqlFactory<Program, ApplicationDbContext> factory) : base(factory)
    {
        _channel = factory.Channel;
    }

    [Fact]
    public async Task Should_Be_User_Count_Is_Five()
    {
        // Arrange
        var client = new UsersGrpc.UsersGrpcClient(_channel);

        // Act
        var response = await client.GetUsersAsync(new GetUserRequest { });

        // Assert
        response.Should().NotBeNull();
    }
}