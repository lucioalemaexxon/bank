using Bank.Loans.Application.Features.Fees.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Bank.Loans.Application.Features.Fees.Queries
{
    public class FindAllFeesQuery : IRequest<IEnumerable<FeeDto>>
    {

    }
}
