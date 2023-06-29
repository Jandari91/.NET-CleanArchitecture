using Api.Users;
using FluentAssertions;
using Grpc.Net.Client;
using Infrastructure.EFCore;
using Xunit;
using Common;
using Application.Mappers;
using EntityUser = Domain.Entities.User;
using DtoUser = Api.Users.User;

namespace CleanArchitecture.IntegratedTest;

public class UserServiceInPostgresTests : TestBase<TestPostgreSqlFactory<Program, ApplicationDbContext>>
{
    private readonly GrpcChannel _channel;
    private readonly IMapper _mapper;
    public UserServiceInPostgresTests(TestPostgreSqlFactory<Program, ApplicationDbContext> factory) : base(factory)
    {
        _channel = factory.Channel;
        _mapper = factory.Mapper;
    }

    [Fact]
    public async Task Should_Be_User_Count_Is_Five()
    {
        // Arrange
        var client = new UsersGrpc.UsersGrpcClient(_channel);

        // Act
        var response = await client.GetUsersAsync(new GetUserRequest { });
        var result  = _mapper.Map<IEnumerable<EntityUser>>(response.Users);
        // Assert

        result.Should().HaveCount(5);
        result.Should().SatisfyRespectively(
            first =>
            {
                first.Id.Should().Be(1);
                first.Name.Should().Be("박영석");
                first.Email.Should().Be("bak@gmail.com");
            },
            second =>
            {
                second.Id.Should().Be(2);
                second.Name.Should().Be("이건우");
                second.Email.Should().Be("lee@gmail.com");
            },
            third =>
            {
                third.Id.Should().Be(3);
                third.Name.Should().Be("조범희");
                third.Email.Should().Be("jo@gmail.com");
            },
            fourth =>
            {
                fourth.Id.Should().Be(4);
                fourth.Name.Should().Be("안성윤");
                fourth.Email.Should().Be("an@gmail.com");
            },
            fifth =>
            {
                fifth.Id.Should().Be(5);
                fifth.Name.Should().Be("장동계");
                fifth.Email.Should().Be("jang@gmail.com");
            });
    }
}