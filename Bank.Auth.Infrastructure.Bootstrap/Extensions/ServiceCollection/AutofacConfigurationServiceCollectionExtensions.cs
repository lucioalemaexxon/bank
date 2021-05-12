using Autofac;
using Bank.Auth.Infrastructure.Bootstrap.AutofacModules;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Bank.Auth.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class AutofacConfigurationServiceCollectionExtensions
    {
        public static void AddConfigurationAutofac(this ContainerBuilder builder, IConfiguration configuration, IWebHostEnvironment env)
        {
            builder.RegisterModule(new InfrastructureModule(configuration, env));
            builder.RegisterModule(new MediatorModule(bool.Parse(configuration["CommandLoggingEnabled"])));
        }
    }
}
