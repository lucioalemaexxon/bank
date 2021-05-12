using Bank.Loans.Application.Features.Rates.Dtos;
using Bank.Loans.Application.Features.Rates.Queries;
using Bank.Loans.Domain.Rates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Loans.Application.Features.Loans.Queries
{
    public class FindAllRatesQueryHandler : IRequestHandler<FindAllRatesQuery, IEnumerable<RateDto>>
    {
        private readonly IRateRepository rateRepository;

        public FindAllRatesQueryHandler(IRateRepository rateRepository)
        {
            this.rateRepository = rateRepository ?? throw new ArgumentNullException(nameof(rateRepository));
        }

        public async Task<IEnumerable<RateDto>> Handle(FindAllRatesQuery request, CancellationToken cancellationToken)
        {
            var result = await this.rateRepository.FindAll();
            return result.Select(x => RateDto.FromDomain(x)).ToList();
        }
    }
}
