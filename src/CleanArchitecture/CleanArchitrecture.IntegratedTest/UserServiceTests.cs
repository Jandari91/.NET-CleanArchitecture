using Api.Users;
using Common;
using FluentAssertions;
using Grpc.Net.Client;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace CleanArchitrecture.IntegratedTest;

public class UserServiceTests : IntegratedTestBase
{
    private readonly GrpcChannel _channel;
    public UserServiceTests(IntegratedTestFactory<Program> factory) : base(factory)
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
        response.Users.Count.Should().Be(1);
    }
}
