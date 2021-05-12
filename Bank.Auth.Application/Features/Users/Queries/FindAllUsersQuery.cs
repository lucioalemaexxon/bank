using System.Collections.Generic;
using Bank.Auth.Application.Features.Users.Dtos;
using MediatR;

namespace Bank.Auth.Application.Features.Users.Queries
{
    public class FindAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
        
    }
}
