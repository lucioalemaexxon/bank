using System;
using MediatR;

namespace Bank.Loans.Application.Features.Loans.Commands
{
    public class CreateLoanCommand : IRequest<CreateLoanResult>
    {
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public Guid RateId { get; set; }
        public Guid FeeId { get; set; }
    }
}
