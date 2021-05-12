using Bank.Loans.Application.Features.Rates.Commands;
using FluentValidation;

namespace Bank.Loans.Application.Features.Rates.Validations
{
    public class DeleteRateCommandValidation : AbstractValidator<DeleteRateCommand>
    {
        public DeleteRateCommandValidation()
        {
            this.RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("Rate id must not be empty");
        }
    }
}
