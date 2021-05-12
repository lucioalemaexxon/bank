using Bank.Loans.Domain.Fees;
using Bank.Loans.Domain.Rates;
using Microsoft.EntityFrameworkCore;
using Bank.Loans.Domain.Loans;

namespace Bank.Loans.Infrastructure.DataAccess.EF
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options)
        { }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Fee> Fees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
