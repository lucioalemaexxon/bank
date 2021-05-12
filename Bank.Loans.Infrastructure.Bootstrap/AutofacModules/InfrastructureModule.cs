//using Autofac;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;

//namespace Bank.Loans.Infrastructure.Bootstrap.AutofacModules
//{
//    public class InfrastructureModule : Module
//    {
//        private readonly IConfiguration configuration;
//        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

//        public InfrastructureModule(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
//        {
//            this.configuration = configuration;
//            this.env = env;
//        }

//        protected override void Load(ContainerBuilder builder)
//        {
//            //if (env.EnvironmentName == Environments.Development)
//            //{
//            //    builder.RegisterType<AspNetCoreConfigurationProvider>()
//            //        .As<ICredentialProvider>()
//            //        .WithParameter("configuration", configuration)
//            //        .WithParameter("userKey", "Database:UserName")
//            //        .WithParameter("passwordKey", "Database:Password")
//            //        .SingleInstance();
//            //}
//        }
//    }
//}
