using System;
using MediatR;

namespace Bank.Loans.Application.Features.Rates.Commands
{
    public class DeleteRateCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
