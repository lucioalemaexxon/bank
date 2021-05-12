using System.Linq;

namespace Bank.Loans.Infrastructure.DataAccess.EF.Init
{
    public class DataLoader
    {
        private readonly LoanDbContext dbContext;

        public DataLoader(LoanDbContext context)
        {
            dbContext = context;
        }

        public void Seed()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            if (dbContext.Loans.Any())
            {
                return;
            }

            var rates = DemoRateFactory.SeedRates();
            dbContext.Rates.AddRange(rates);

            var fees = DemoFeeFactory.SeedFees();
            dbContext.Fees.AddRange(fees);

            dbContext.Loans.Add(
                DemoLoanFactory.FirstLoan(
                    rates.FirstOrDefault(x => x.AnnualInterestRate == 5m),
                    fees.FirstOrDefault(x => x.Rate == 1 && x.Amount == 10000)
                    ));

            dbContext.SaveChanges();
        }
    }
}
