using Microsoft.AspNetCore.Builder;

namespace Bank.Loans.Infrastructure.Bootstrap.ApplicationBuilder
{
    public static class CorsApplicationBuilderExtensions
    {
        public static void UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
        }
    }
}
