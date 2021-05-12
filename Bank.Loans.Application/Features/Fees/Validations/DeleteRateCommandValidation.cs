using Bank.Loans.Application.Features.Fees.Commands;
using FluentValidation;

namespace Bank.Loans.Application.Features.Fees.Validations
{
    public class DeleteRateCommandValidation : AbstractValidator<DeleteFeeCommand>
    {
        public DeleteRateCommandValidation()
        {
            this.RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("Fee id must not be empty");
        }
    }
}
