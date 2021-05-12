using Bank.Loans.Domain.Rates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Loans.Infrastructure.DataAccess.EF
{
    public class RateRepository : IRateRepository
    {
        private readonly LoanDbContext loanDbContext;

        public RateRepository(LoanDbContext loanDbContext)
        {
            this.loanDbContext = loanDbContext ?? throw new ArgumentNullException(nameof(LoanDbContext));
        }

        public async Task<IEnumerable<Rate>> FindAll()
        {
            return await loanDbContext
               .Rates
               .ToListAsync();
        }

        public async Task<Rate> FindById(Guid id)
        {
            return await loanDbContext
                .Rates
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Rate> Add(Rate Rate)
        {
            await loanDbContext.AddAsync(Rate);
            await loanDbContext.SaveChangesAsync();
            return Rate;
        }

        public async Task Delete(Guid id)
        {
            var rate = await loanDbContext
                            .Rates
                            .FirstOrDefaultAsync(x => x.Id == id);
            loanDbContext.Remove(rate);
            await loanDbContext.SaveChangesAsync();
        }
    }
}
