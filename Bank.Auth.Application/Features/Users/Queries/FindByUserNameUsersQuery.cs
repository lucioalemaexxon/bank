using Bank.Auth.Application.Features.Users.Dtos;
using MediatR;

namespace Bank.Auth.Application.Features.Users.Queries
{
    public class FindByUserNameUsersQuery : IRequest<UserDto>
    {
        public string UserName { get; set; }
        public FindByUserNameUsersQuery(string userName)
        {
            UserName = userName;
        }
    }
}
