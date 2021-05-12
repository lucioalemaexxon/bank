using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bank.Loans.Domain.Loans;

namespace Bank.Loans.Domain.Rates
{
    public class Rate
    {
        [Key]
        public Guid Id { get; private set; }
        [Required]
        public decimal AnnualInterestRate { get; private set; }

        public IEnumerable<Loan> Loans { get; private set; }

        public Rate(decimal annualInterestRate)
        {
            this.Id = Guid.NewGuid();
            this.AnnualInterestRate = (annualInterestRate > 0) ? annualInterestRate : throw new ArgumentNullException();
        }
    }
}
