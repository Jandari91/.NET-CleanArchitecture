using Api.Users;
using Grpc.Core;
namespace CleanArchitecture.Services
{
    public class UsersService : UsersGrpc.UsersGrpcBase
    {
        private readonly ILogger<UsersService> _logger;
        public UsersService(ILogger<UsersService> logger)
        {
            _logger = logger;
        }

        public override async Task<GetUserReply> GetUsers(GetUserRequest request, ServerCallContext context)
        {
            return await Task.FromResult(new GetUserReply
            {
                Users = 
                { 
                    new List<User>
                    {
                        new User()
                        {
                            Id = 1,
                            Email = "mirero@mail.com",
                            Name = "mirero",
                        }
                    }
                }
            });
        }
    }
}