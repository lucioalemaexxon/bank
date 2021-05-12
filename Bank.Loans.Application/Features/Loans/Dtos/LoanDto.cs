using System;
using Bank.Loans.Domain.Loans;

namespace Bank.Loans.Application.Features.Loans.Dtos
{
    public class LoanDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public decimal Rate { get; set; }
        public decimal AdministrationFee { get; set; }
        public Status Status { get; set; }
        public decimal AOP { get; set; }
        public decimal MonthlyCost { get; set; }
        public decimal TotalInterestRatePaid { get; set; }
        public decimal TotalAdministrativeFeesPaid { get; set; }

        public static LoanDto FromDomain(Loan loan)
        {
            return new LoanDto
            {
                Id = loan.Id,
                Amount = loan.Amount,
                Duration = loan.Duration,
                Rate = Math.Round(loan.Rate.AnnualInterestRate, 2),
                AdministrationFee = Math.Round(loan.AdministrationFee, 2),
                Status = loan.Status,
                AOP = Math.Round(loan.AOP, 2),
                MonthlyCost = Math.Round(loan.MonthlyCost, 2),
                TotalInterestRatePaid = Math.Round(loan.TotalInterestRatePaid, 2),
                TotalAdministrativeFeesPaid = Math.Round(loan.TotalAdministrativeFeesPaid, 2)
            };
        }
    }
}
