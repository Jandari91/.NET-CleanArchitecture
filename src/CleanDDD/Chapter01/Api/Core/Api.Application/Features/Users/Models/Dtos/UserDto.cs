namespace Api.Application.Features.Users.Models.Dtos;

public sealed record UserDto(string UserId, string Name, string Email, bool IsActive);