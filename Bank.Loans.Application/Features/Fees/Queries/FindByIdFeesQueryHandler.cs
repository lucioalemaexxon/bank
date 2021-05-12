using Bank.Loans.Application.Features.Fees.Dtos;
using Bank.Loans.Domain.Fees;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Loans.Application.Features.Fees.Queries
{
    public class FindByIdFeesQueryHandler : IRequestHandler<FindByIdFeesQuery, FeeDto>
    {
        private readonly IFeeRepository feeRepository;

        public FindByIdFeesQueryHandler(IFeeRepository feeRepository)
        {
            this.feeRepository = feeRepository ?? throw new ArgumentNullException(nameof(feeRepository));
        }

        public async Task<FeeDto> Handle(FindByIdFeesQuery request, CancellationToken cancellationToken)
        {
            var result = await this.feeRepository.FindById(request.Id);
            return FeeDto.FromDomain(result);
        }
    }
}
