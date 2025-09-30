using Api.Application.Features.Users.Queries.GetUsers;
using CleanDDD.Contracts.Users.v1;
using Grpc.Core;
using MediatR;
namespace Api.Service.Controllers;

public class UserController : UserService.UserServiceBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public override async Task<GetUsersResponse> GetUsers(GetUsersRequest request, ServerCallContext context)
    {
        var res = await _mediator.Send(new GetUsersQuery(), context.CancellationToken);

        if (!res.IsSuccess)
            throw new RpcException(new Status(StatusCode.Internal, res.Error.ToString()));

        var rsp = new GetUsersResponse();
        rsp.Items.AddRange(res.Value.Select(u => new User
        {
            UserId = u.UserId,
            Name = u.Name,
            Email = u.Email,
            IsActive = u.IsActive
        }));
        return rsp;
    }
}
