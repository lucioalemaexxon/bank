using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Auth.Domain.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindAll();
        Task<User> FindByUserName(string userName);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task Delete(string userName);
    }
}
