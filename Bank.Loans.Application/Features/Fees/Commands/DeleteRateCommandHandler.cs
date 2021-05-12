using System;
using System.Threading;
using System.Threading.Tasks;
using Bank.Loans.Domain.Fees;
using MediatR;

namespace Bank.Loans.Application.Features.Fees.Commands
{
    public class DeleteFeeCommandHandler : IRequestHandler<DeleteFeeCommand, Unit>
    {
        private readonly IFeeRepository feeRepository;

        public DeleteFeeCommandHandler(IFeeRepository feeRepository)
        {
            this.feeRepository = feeRepository ?? throw new ArgumentNullException(nameof(feeRepository));
        }

        public async Task<Unit> Handle(DeleteFeeCommand request, CancellationToken cancellationToken)
        {
            await this.feeRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
