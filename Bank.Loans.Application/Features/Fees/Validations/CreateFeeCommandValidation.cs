using Bank.Loans.Application.Features.Fees.Commands;
using FluentValidation;

namespace Bank.Loans.Application.Features.Fees.Validations
{
    public class CreateFeeCommandValidation : AbstractValidator<CreateFeeCommand>
    {
        public CreateFeeCommandValidation()
        {
            this.RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty");
            this.RuleFor(command => command.Rate)
                .GreaterThan(0)
                .WithMessage("Rate must be greater than 0");
            this.RuleFor(command => command.Amount)
                .GreaterThan(0)
                .WithMessage("Ammount must be greater than 0");
        }
    }
}
