using Autofac;
using Bank.Auth.Application.Behaviors;
using Bank.Auth.Application.Features.Users.Queries;
using MediatR;

namespace Bank.Auth.Infrastructure.Bootstrap.AutofacModules
{
    internal class MediatorModule : Module
    {
        private readonly bool enableCommandLogging;

        public MediatorModule(bool enableCommandLogging)
        {
            this.enableCommandLogging = enableCommandLogging;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(FindAllUsersQuery).Assembly)
                .AsImplementedInterfaces();

            if (this.enableCommandLogging)
            {
                builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            }

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
