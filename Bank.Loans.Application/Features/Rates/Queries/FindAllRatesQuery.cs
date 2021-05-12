using Bank.Loans.Application.Features.Rates.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Bank.Loans.Application.Features.Rates.Queries
{
    public class FindAllRatesQuery : IRequest<IEnumerable<RateDto>>
    {

    }
}
