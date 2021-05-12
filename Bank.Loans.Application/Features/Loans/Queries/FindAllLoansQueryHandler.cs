using Bank.Loans.Application.Features.Loans.Dtos;
using Bank.Loans.Domain.Loans;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Loans.Application.Features.Loans.Queries
{
    public class FindAllLoansQueryHandler : IRequestHandler<FindAllLoansQuery, IEnumerable<LoanDto>>
    {
        private readonly ILoanRepository loanRepository;

        public FindAllLoansQueryHandler(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));
        }

        public async Task<IEnumerable<LoanDto>> Handle(FindAllLoansQuery request, CancellationToken cancellationToken)
        {
            var result = await this.loanRepository.FindAll();
            return result.Select(x => LoanDto.FromDomain(x)).ToList();
        }
    }
}
