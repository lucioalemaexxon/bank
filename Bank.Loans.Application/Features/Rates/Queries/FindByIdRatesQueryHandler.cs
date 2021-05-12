using Bank.Loans.Application.Features.Rates.Dtos;
using Bank.Loans.Domain.Rates;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Loans.Application.Features.Rates.Queries
{
    public class FindByIdRatesQueryHandler : IRequestHandler<FindByIdRatesQuery, RateDto>
    {
        private readonly IRateRepository RateRepository;

        public FindByIdRatesQueryHandler(IRateRepository RateRepository)
        {
            this.RateRepository = RateRepository ?? throw new ArgumentNullException(nameof(RateRepository));
        }

        public async Task<RateDto> Handle(FindByIdRatesQuery request, CancellationToken cancellationToken)
        {
            var result = await this.RateRepository.FindById(request.Id);
            return RateDto.FromDomain(result);
        }
    }
}
