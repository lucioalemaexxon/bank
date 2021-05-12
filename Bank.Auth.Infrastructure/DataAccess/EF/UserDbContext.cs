using Bank.Auth.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bank.Auth.Infrastructure.DataAccess.EF
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
