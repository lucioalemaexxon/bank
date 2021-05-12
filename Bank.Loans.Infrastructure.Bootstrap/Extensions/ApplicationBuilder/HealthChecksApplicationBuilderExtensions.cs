using Microsoft.AspNetCore.Builder;

namespace Bank.Loans.Infrastructure.Bootstrap.ApplicationBuilder
{
    public static class HealthChecksApplicationBuilderExtensions
    {
        public static void UseMicroserviceHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health");
        }
    }
}
