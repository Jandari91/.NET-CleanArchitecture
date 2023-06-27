using Api.Users;
using Application.Mappers;
using Common;
using FluentAssertions;
using Grpc.Net.Client;
using Xunit;

using EntityUser = Domain.Entities.User;

namespace CleanArchitecture.UnitTest;

public class UserServiceTests : TestBase
{
    private readonly GrpcChannel _channel;
    private readonly IMapper _mapper;
    public UserServiceTests(TestFactory<Program> factory) : base(factory)
    {
        _channel = factory.Channel;
        _mapper = factory.Mapper;
    }

    [Fact]
    public async Task Should_Be_Get_Users()
    {
        // Arrange
        var client = new UsersGrpc.UsersGrpcClient(_channel);

        // Act
        var response = await client.GetUsersAsync(new GetUserRequest { });

        // Assert
        var entities = _mapper.Map<IEnumerable<EntityUser>>(response.Users);
        entities.Should().HaveCount(1);
    }
}
