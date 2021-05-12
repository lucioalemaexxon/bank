using Autofac;
using Bank.Loans.Application.Behaviors;
using Bank.Loans.Application.Features.Loans.Queries;
using MediatR;

namespace Bank.Loans.Infrastructure.Bootstrap.AutofacModules
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
            builder.RegisterAssemblyTypes(typeof(FindAllLoansQuery).Assembly)
                .AsImplementedInterfaces();

            if (this.enableCommandLogging)
            {
                builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            }

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
