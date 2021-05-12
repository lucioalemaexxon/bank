using Bank.Loans.Application.Features.Loans.Dtos;
using MediatR;
using System;

namespace Bank.Loans.Application.Features.Loans.Queries
{
    public class FindByIdLoansQuery : IRequest<LoanDto>
    {
        public Guid Id { get; set; }
    }
}
