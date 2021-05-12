using System;
using System.Threading;
using System.Threading.Tasks;
using Bank.Loans.Domain.Rates;
using MediatR;

namespace Bank.Loans.Application.Features.Rates.Commands
{
    public class DeleteRateCommandHandler : IRequestHandler<DeleteRateCommand, Unit>
    {
        private readonly IRateRepository rateRepository;

        public DeleteRateCommandHandler(IRateRepository rateRepository)
        {
            this.rateRepository = rateRepository ?? throw new ArgumentNullException(nameof(rateRepository));
        }

        public async Task<Unit> Handle(DeleteRateCommand request, CancellationToken cancellationToken)
        {
            await this.rateRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
