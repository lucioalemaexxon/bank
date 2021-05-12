using Bank.Loans.Application.Features.Loans.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Bank.Loans.Application.Features.Loans.Queries
{
    public class FindAllLoansQuery : IRequest<IEnumerable<LoanDto>>
    {

    }
}
