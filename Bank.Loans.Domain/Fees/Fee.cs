using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.Loans.Domain.Fees
{
    public class Fee
    {
        [Key]
        public Guid Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public decimal Rate { get; private set; }
        [Required]
        public decimal Amount { get; private set; }

        public Fee(string name, decimal rate, decimal amount)
        {
            this.Id = Guid.NewGuid();
            this.Name = !string.IsNullOrEmpty(name) ? name: throw new ArgumentException();
            this.Rate = rate >= 0 ? rate : throw new ArgumentException();
            this.Amount = amount >= 0 ? amount : throw new ArgumentException();
        }
    }
}
