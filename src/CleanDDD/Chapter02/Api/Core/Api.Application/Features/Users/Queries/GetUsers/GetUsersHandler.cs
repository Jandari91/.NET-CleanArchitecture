using Api.Application.Features.Users.Models.Dtos;
using Api.Domain.Repositories;
using Kernel.Results;
using MediatR;

namespace Api.Application.Features.Users.Queries.GetUsers;

public sealed class GetUsersHandler : IRequestHandler<GetUsersQuery, Result<List<UserDto>>>
{
    private readonly IUserRepository _users;

    public GetUsersHandler(IUserRepository users) => _users = users;

    public async Task<Result<List<UserDto>>> Handle(GetUsersQuery req, CancellationToken cancellationToken)
    {
        var list = await _users.GetAllAsync(cancellationToken);

        var dto = list.Select(u =>
            new UserDto(
                u.UserId.ToString(),
                u.Name.ToString(),
                u.Email.ToString(),
                u.IsActive))
            .ToList();

        return Result<List<UserDto>>.Ok(dto);
    }
}
