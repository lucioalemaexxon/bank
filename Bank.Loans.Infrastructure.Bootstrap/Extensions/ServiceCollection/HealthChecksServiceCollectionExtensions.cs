using Microsoft.Extensions.DependencyInjection;

namespace Bank.Loans.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class HealthChecksServiceCollectionExtensions
    {
        public static void AddMicroserviceHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }
    }
}
