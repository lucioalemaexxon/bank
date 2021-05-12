using Bank.Auth.Domain.Users;
using Bank.Auth.Infrastructure.DataAccess.EF;
using Bank.Auth.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Loans.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class EFServiceCollectionExtensions
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryDatabase = bool.Parse(configuration["AppSettings:UseInMemoryDatabase"]);

            services.AddDbContext<UserDbContext>(options =>
            {
                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase("Users");
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("Users"));
                }
            });

            //services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
