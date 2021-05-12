using System;
using Bank.Loans.Domain.Rates;

namespace Bank.Loans.Application.Features.Rates.Dtos
{
    public class RateDto
    {
        public Guid Id { get; set; }
        public decimal AnnualInterestRate { get; set; }

        public static RateDto FromDomain(Rate rate)
        {
            return new RateDto
            {
                Id = rate.Id,
                AnnualInterestRate = rate.AnnualInterestRate
            };
        }
    }
}
