using Bank.Loans.Domain.Fees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Loans.Infrastructure.DataAccess.EF
{
    public class FeeRepository : IFeeRepository
    {
        private readonly LoanDbContext loanDbContext;

        public FeeRepository(LoanDbContext loanDbContext)
        {
            this.loanDbContext = loanDbContext ?? throw new ArgumentNullException(nameof(LoanDbContext));
        }

        public async Task<IEnumerable<Fee>> FindAll()
        {
            return await loanDbContext
               .Fees
               .ToListAsync();
        }

        public async Task<Fee> FindById(Guid id)
        {
            return await loanDbContext
                .Fees
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Fee> Add(Fee Fee)
        {
            await loanDbContext.AddAsync(Fee);
            await loanDbContext.SaveChangesAsync();
            return Fee;
        }

        public async Task Delete(Guid id)
        {
            var fee = await loanDbContext
                            .Fees
                            .FirstOrDefaultAsync(x => x.Id == id);
            loanDbContext.Remove(fee);
            await loanDbContext.SaveChangesAsync();
        }
    }
}
