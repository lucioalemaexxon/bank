using System;
using System.Threading;
using System.Threading.Tasks;
using Bank.Auth.Domain.Users;
using MediatR;

namespace Bank.Auth.Application.Features.Users.Commands
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly IUserService userService;

        public AuthenticateUserCommandHandler(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await userService.Authenticate(request.UserName, request.Password);
            return result;
        }
    }
}
