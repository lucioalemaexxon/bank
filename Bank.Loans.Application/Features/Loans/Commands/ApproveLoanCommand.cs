using System;
using MediatR;

namespace Bank.Loans.Application.Features.Loans.Commands
{
    public class ApproveLoanCommand : IRequest<ApproveLoanResult>
    {
        public Guid Id { get; set; }
    }
}
