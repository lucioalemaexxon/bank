using Bank.Loans.Domain.Fees;
using Bank.Loans.Domain.Rates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bank.Loans.Domain.Loans;
using Bank.Loans.Infrastructure.DataAccess.EF;

namespace Bank.Loans.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class EFServiceCollectionExtensions
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryDatabase = bool.Parse(configuration["AppSettings:UseInMemoryDatabase"]);

            services.AddDbContext<LoanDbContext>(options =>
            {
                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase("Loans");
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("Loans"));
                }
            });

            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IFeeRepository, FeeRepository>();
            return services;
        }
    }
}
