using Bank.Loans.Application.Features.Fees.Dtos;
using MediatR;
using System;

namespace Bank.Loans.Application.Features.Fees.Queries
{
    public class FindByIdFeesQuery : IRequest<FeeDto>
    {
        public Guid Id { get; set; }
    }
}
