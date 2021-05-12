using System.Threading.Tasks;

namespace Bank.Auth.Domain.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(string userName, string password);
    }
}
