using Bank.Loans.Domain.Fees;
using Bank.Loans.Domain.Rates;
using Bank.Loans.Domain.Loans;

namespace Bank.Loans.Infrastructure.DataAccess.EF.Init
{
    public class DemoLoanFactory
    {
        internal static Loan FirstLoan(Rate rate, Fee fee)
        {
            return Loan.Create(500000m, 120, Status.Draft, rate, fee);
        }
    }
}
