using Autofac;
using Bank.Auth.Domain.Users;
using Bank.Auth.Infrastructure.Repositories;
using Bank.Auth.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Bank.Auth.Infrastructure.Bootstrap.AutofacModules
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public InfrastructureModule(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UserService>()
             .As<IUserService>()
             .WithParameter("configuration", configuration)
             .InstancePerLifetimeScope();
        }
    }
}
