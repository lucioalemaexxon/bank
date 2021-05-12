using System;
using System.Threading;
using System.Threading.Tasks;
using Bank.Loans.Domain.Loans;
using MediatR;

namespace Bank.Loans.Application.Features.Loans.Commands
{
    public class ApproveLoanCommandHandler : IRequestHandler<ApproveLoanCommand, ApproveLoanResult>

    {
        private readonly ILoanRepository loanRepository;

        public ApproveLoanCommandHandler(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));

        }

        public async Task<ApproveLoanResult> Handle(ApproveLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await loanRepository.FindById(request.Id);
            loan.Approve();
            await loanRepository.Update(loan);
            return new ApproveLoanResult { Id = loan.Id };
        }
    }
}
