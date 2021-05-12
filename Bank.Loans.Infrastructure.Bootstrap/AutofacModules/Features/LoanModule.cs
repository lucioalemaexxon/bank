using Autofac;

namespace Bank.Loans.Infrastructure.Bootstrap.AutofacModules.Features
{
    public class LoanModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<LoanRepository>()
            // .As<ILoanRepository>()
            // .InstancePerLifetimeScope();
        }
    }
}
