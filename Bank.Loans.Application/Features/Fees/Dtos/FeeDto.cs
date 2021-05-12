using System;
using Bank.Loans.Domain.Fees;

namespace Bank.Loans.Application.Features.Fees.Dtos
{
    public class FeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }

        public static FeeDto FromDomain(Fee fee)
        {
            return new FeeDto
            {
                Id = fee.Id,
                Name = fee.Name,
                Rate = fee.Rate,
                Amount = fee.Amount
            };
        }
    }
}
