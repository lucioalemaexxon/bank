using Bank.Loans.Application.Features.Fees.Dtos;
using Bank.Loans.Application.Features.Fees.Queries;
using Bank.Loans.Domain.Fees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Loans.Application.Features.Loans.Queries
{
    public class FindAllFeesQueryHandler : IRequestHandler<FindAllFeesQuery, IEnumerable<FeeDto>>
    {
        private readonly IFeeRepository feeRepository;

        public FindAllFeesQueryHandler(IFeeRepository feeRepository)
        {
            this.feeRepository = feeRepository ?? throw new ArgumentNullException(nameof(feeRepository));
        }

        public async Task<IEnumerable<FeeDto>> Handle(FindAllFeesQuery request, CancellationToken cancellationToken)
        {
            var result = await this.feeRepository.FindAll();
            return result.Select(x => FeeDto.FromDomain(x)).ToList();
        }
    }
}
