using System;
using MediatR;

namespace Bank.Loans.Application.Features.Fees.Commands
{
    public class DeleteFeeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
