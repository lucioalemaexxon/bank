using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bank.Auth.Domain.Users;
using Bank.Auth.Infrastructure.DataAccess.EF;
using Microsoft.EntityFrameworkCore;

namespace Bank.Auth.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext userDbContext;

        public UserRepository(UserDbContext UserDbContext)
        {
            this.userDbContext = UserDbContext ?? throw new ArgumentNullException(nameof(UserDbContext));
        }

        public async Task<IEnumerable<User>> FindAll()
        {
            return await userDbContext
               .Users
               .ToListAsync();
        }

        public async Task<User> FindByUserName(string userName)
        {
            return await userDbContext
                .Users
                .FirstOrDefaultAsync(p => p.UserName == userName);
        }

        public async Task<User> Add(User user)
        {
            await userDbContext.AddAsync(user);
            await userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            userDbContext.Update(user);
            await userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task Delete(string userName)
        {
            var fee = await userDbContext
                            .Users
                            .FirstOrDefaultAsync(x => x.UserName == userName);
            userDbContext.Remove(fee);
            await userDbContext.SaveChangesAsync();
        }
    }
}
