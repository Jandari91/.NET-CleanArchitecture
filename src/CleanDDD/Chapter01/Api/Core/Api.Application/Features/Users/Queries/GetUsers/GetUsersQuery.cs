using Api.Application.Features.Users.Models.Dtos;
using Kernel.Results;
using MediatR;

namespace Api.Application.Features.Users.Queries.GetUsers;

public sealed record GetUsersQuery() : IRequest<Result<List<UserDto>>>;
