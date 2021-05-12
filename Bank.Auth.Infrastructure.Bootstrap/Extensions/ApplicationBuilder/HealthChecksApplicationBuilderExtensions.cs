using Microsoft.AspNetCore.Builder;

namespace Bank.Auth.Infrastructure.Bootstrap.Extensions.ApplicationBuilder
{
    public static class HealthChecksApplicationBuilderExtensions
    {
        public static void UseMicroserviceHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health");
        }
    }
}
