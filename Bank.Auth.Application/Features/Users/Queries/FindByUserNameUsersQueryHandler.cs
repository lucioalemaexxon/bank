using Bank.Auth.Application.Features.Users.Dtos;
using Bank.Auth.Domain.Users;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Auth.Application.Features.Users.Queries
{
    public class FindByUserNameUsersQueryHandler : IRequestHandler<FindByUserNameUsersQuery, UserDto>
    {
        private readonly IUserRepository UserRepository;

        public FindByUserNameUsersQueryHandler(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository ?? throw new ArgumentNullException(nameof(UserRepository));
        }

        public async Task<UserDto> Handle(FindByUserNameUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await UserRepository.FindByUserName(request.UserName);
            return UserDto.FromDomain(result);
        }
    }
}
