using Autofac;
using Bank.Loans.Infrastructure.Bootstrap.AutofacModules;
using Bank.Loans.Infrastructure.Bootstrap.AutofacModules.Features;
using Microsoft.Extensions.Configuration;

namespace Bank.Loans.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class AutofacConfigurationServiceCollectionExtensions
    {
        public static void AddConfigurationAutofac(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterModule(new MediatorModule(bool.Parse(configuration["CommandLoggingEnabled"])));
        }
    }
}
