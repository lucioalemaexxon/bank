using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bank.Auth.Domain.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Bank.Auth.Infrastructure.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.configuration = configuration;
        }

        public async Task<string> Authenticate(string userName, string password)
        {
            var user = await userRepository.FindByUserName(userName);
            if (user == null)
                return null;

            if (!user.PasswordMatches(password))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var symmetricKey = this.configuration.GetValue<string>("AppSettings:SymmetricKey");
            var key = Encoding.ASCII.GetBytes(symmetricKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim("avatar", user.Avatar)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
