using Bank.Auth.Domain.Users;

namespace Bank.Auth.Application.Features.Users.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }

        public static UserDto FromDomain(User user)
        {
            return new UserDto
            {
                UserName = user.UserName,
                Password = user.Password,
                Avatar = user.Avatar
            };
        }
    }
}
