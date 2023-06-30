using Api.Users;
using CleanArchitecture.Core.Application;
using Grpc.Core;

namespace CleanArchitecture.Services
{
    public class UserController : UsersGrpc.UsersGrpcBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(
            ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public override async Task<GetUserReply> GetUsers(GetUserRequest request, ServerCallContext context)
        {
            var dtos = await _userService.GetAllUsers();
            return await Task.FromResult(new GetUserReply()
            {
                Users = { dtos },
            });
        }
    }
}