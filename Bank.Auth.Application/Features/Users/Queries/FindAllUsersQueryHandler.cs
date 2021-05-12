using Bank.Auth.Application.Features.Users.Dtos;
using Bank.Auth.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Auth.Application.Features.Users.Queries
{
    public class FindAllUsersQueryHandler : IRequestHandler<FindAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository userRepository;

        public FindAllUsersQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<IEnumerable<UserDto>> Handle(FindAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await userRepository.FindAll();
            return result.Select(x => UserDto.FromDomain(x)).ToList();
        }
    }
}
