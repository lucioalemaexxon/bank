using System.Collections.Generic;
using System.Linq;
using Bank.Auth.Domain.Users;

namespace Bank.Auth.Infrastructure.DataAccess.EF.Init
{
    public class DataLoader
    {
        private readonly UserDbContext dbContext;

        public DataLoader(UserDbContext context)
        {
            dbContext = context;
        }

        public void Seed()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            if (dbContext.Users.Any())
            {
                return;
            }

            dbContext.Users.AddRange(new List<User>
            {
                new User("admin","pa$$w0rd","admin.png"),
                new User("userTest", "pa$$w0rd", "user.png")
            });

            dbContext.SaveChanges();
        }
    }
}
