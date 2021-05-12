using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bank.Loans.Domain.Exceptions;
using Bank.Loans.Domain.Fees;
using Bank.Loans.Domain.Rates;

namespace Bank.Loans.Domain.Loans
{
    public class Loan
    {
        [Key]
        public Guid Id { get; private set; }
        [Required]
        public decimal Amount { get; private set; }
        [Required]
        public int Duration { get; private set; }
        [ForeignKey("Rate")]
        public Guid RateId { get; private set; }
        [Required]
        public decimal AdministrationFee { get; private set; }
        [Required]
        public Status Status { get; private set; }
        [Required]
        public decimal AOP { get; private set; }
        [Required]
        public decimal MonthlyCost { get; private set; }
        [Required]
        public decimal TotalInterestRatePaid { get; private set; }
        [Required]
        public decimal TotalAdministrativeFeesPaid { get; private set; }

        public Rate Rate { get; private set; }

        private Loan() { }
        
        private Loan(decimal amount, int duration, Status status, Rate rate, Fee fee)
        {
            this.Id = Guid.NewGuid();
            this.Amount = (amount > 0) ? amount : throw new ArgumentNullException();
            this.Duration = (duration > 0) ? duration : throw new ArgumentNullException();
            this.Status = status;
            this.Rate = !rate.Equals(null) ? rate : throw new ArgumentNullException();
            this.AdministrationFee = CalcAdministrationFee(fee) > 0 ? CalcAdministrationFee(fee) : throw new ArgumentException();
            var monthlyCost = CalcMonthlyCost(amount, duration, rate.AnnualInterestRate);
            this.MonthlyCost = monthlyCost > 0 ? monthlyCost : throw new ArgumentNullException();
            var totalInt = CalcTotalInterestRatePaid();
            this.TotalInterestRatePaid = totalInt > 0 ? totalInt : throw new ArgumentException();            
            this.TotalAdministrativeFeesPaid = AdministrationFee > 0 ? AdministrationFee : throw new ArgumentException();
            var aop = CalcAOP();
            this.AOP = (aop > 0) ? aop : throw new ArgumentNullException();
        }

        private decimal CalcAdministrationFee(Fee fee)
        {
            return Math.Min(this.Amount * fee.Rate / 100, fee.Amount);
        }

        private decimal CalcAOP()
        {
            return ((((this.TotalAdministrativeFeesPaid + this.TotalInterestRatePaid) / this.Amount) / (Duration * 365)) * 365) * 100;
        }

        private decimal CalcMonthlyCost(decimal amount, int duration, decimal rate)
        {
            var z = 1 / (1 + (rate / 100) / 12);
            var div = 1 - Math.Pow(Convert.ToDouble(z), duration);
            return (amount * (1 - z)) / (z * Convert.ToDecimal(div));
        }

        private decimal CalcTotalInterestRatePaid()
        {
            return this.MonthlyCost * this.Duration - this.Amount;
        }

        public static Loan Create(decimal amount, int duration, Status status, Rate rate, Fee fee)
        {
            return new Loan(amount, duration, status, rate, fee);
        }

        public void Approve()
        {
            EnsureIsDraft();
            Status = Status.Approved;
        }

        private void EnsureIsDraft()
        {
            if (Status != Status.Draft)
            {
                throw new DomainException("You can approve only draft versions");
            }
        }
    }

    public enum Status
    {
        Draft,
        Approved,
        Paid
    }
}

