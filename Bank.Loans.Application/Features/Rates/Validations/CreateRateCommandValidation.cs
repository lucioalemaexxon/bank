using Bank.Loans.Application.Features.Rates.Commands;
using FluentValidation;

namespace Bank.Loans.Application.Features.Rates.Validations
{
    public class CreateRateCommandValidation : AbstractValidator<CreateRateCommand>
    {
        public CreateRateCommandValidation()
        {
            this.RuleFor(command => command.AnnualInterestRate)
                .GreaterThan(0)
                .WithMessage("Annual rate must be greater than 0");
        }
    }
}
