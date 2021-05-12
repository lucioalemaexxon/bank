using MediatR;

namespace Bank.Auth.Application.Features.Users.Commands
{
    public class AuthenticateUserCommand :IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
