using MediatR;

namespace Bank.Loans.Application.Features.Rates.Commands
{
    public class CreateRateCommand : IRequest<CreateRateResult>
    {
        public decimal AnnualInterestRate { get; set; }
    }
}
