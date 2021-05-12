using Bank.Auth.Infrastructure.DataAccess.EF.Init;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Loans.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class DataLoaderInstallerServiceCollectionExtensions
    {
        public static IServiceCollection AddLoanDemoInitializer(this IServiceCollection services)
        {
            services.AddScoped<DataLoader>();
            return services;
        }
    }
}
