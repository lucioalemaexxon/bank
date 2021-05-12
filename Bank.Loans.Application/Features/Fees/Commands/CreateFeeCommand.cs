using System;
using MediatR;

namespace Bank.Loans.Application.Features.Fees.Commands
{
    public class CreateFeeCommand : IRequest<CreateFeeResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
