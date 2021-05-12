using System.Collections.Generic;
using Bank.Loans.Domain.Fees;

namespace Bank.Loans.Infrastructure.DataAccess.EF.Init
{
    public class DemoFeeFactory
    {
        internal static IList<Fee> SeedFees()
        {
            return new Fee[] {
                new Fee("1% or 10000 kr", 1m, 10000m),
                new Fee("2% or 15000 kr", 2m, 15000m)
            };
        }
    }
}
