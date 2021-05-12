using System;
using System.Threading;
using System.Threading.Tasks;
using Bank.Loans.Domain.Fees;
using MediatR;

namespace Bank.Loans.Application.Features.Fees.Commands
{
    public class CreateFeeCommandHandler : IRequestHandler<CreateFeeCommand, CreateFeeResult>
    {
        private readonly IFeeRepository feeRepository;

        public CreateFeeCommandHandler(IFeeRepository feeRepository)
        {
            this.feeRepository = feeRepository ?? throw new ArgumentNullException(nameof(feeRepository));
        }

        public async Task<CreateFeeResult> Handle(CreateFeeCommand request, CancellationToken cancellationToken)
        {
            var result = await this.feeRepository.Add(new Fee(request.Name, request.Rate, request.Amount));
            return new CreateFeeResult { Id = result.Id };
        }
    }
}
