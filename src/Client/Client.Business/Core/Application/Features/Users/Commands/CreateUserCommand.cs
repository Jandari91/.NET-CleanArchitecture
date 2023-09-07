using Api.Users;
using Application.Mappers;
using Client.Business.Core.Domain.Attributes;
using Client.Business.Core.Domain.Models.Users;
using Grpc.Net.Client;
using LanguageExt;
using MediatR;
using DtoUser = Api.Users.User;

namespace Client.Business.Core.Application.Features.Users.Commands;

[RetryPolicy(RetryCount = 3, SleepDuration = 500)]
public record CreateUserCommand(UserModel userModel) : IRequest<Option<UserModel>>;

public class GetAllUsersQueryHandler : IRequestHandler<CreateUserCommand, Option<UserModel>>
{
    private readonly IMapper _mapper;
    private readonly GrpcChannel _channel;
    public GetAllUsersQueryHandler(IMapper mapper, GrpcChannel channel)
    {
        _mapper = mapper;
        _channel = channel;
    }

    public async Task<Option<UserModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken = default)
    {
        var client = new UsersGrpc.UsersGrpcClient(_channel);

        var user = _mapper.Map<DtoUser>(request.userModel);

        var response = await client.CreateUserAsync(new CreateUserRequest { User = user });

        var result = _mapper.Map<UserModel>(response.User);
        if (result is null)
            return Option<UserModel>.None;

        return Option<UserModel>.Some(result);
    }
}