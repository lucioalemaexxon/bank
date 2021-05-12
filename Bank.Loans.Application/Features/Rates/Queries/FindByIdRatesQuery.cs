using Bank.Loans.Application.Features.Rates.Dtos;
using MediatR;
using System;

namespace Bank.Loans.Application.Features.Rates.Queries
{
    public class FindByIdRatesQuery : IRequest<RateDto>
    {
        public Guid Id { get; set; }
        public FindByIdRatesQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
