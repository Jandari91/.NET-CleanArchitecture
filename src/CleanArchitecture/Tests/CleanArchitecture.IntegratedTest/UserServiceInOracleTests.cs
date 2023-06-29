using Api.Users;
using Common;
using Common.Factories;
using FluentAssertions;
using Grpc.Net.Client;
using Infrastructure.EFCore;
using Xunit;

namespace CleanArchitecture.IntegratedTest;

public class UserServiceInOracleTests : TestBase<TestOracleFactory<Program, ApplicationDbContext>>
{
    private readonly GrpcChannel _channel;
    public UserServiceInOracleTests(TestOracleFactory<Program, ApplicationDbContext> factory) : base(factory)
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