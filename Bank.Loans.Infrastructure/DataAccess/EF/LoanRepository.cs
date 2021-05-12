using Bank.Loans.Domain.Loans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Loans.Infrastructure.DataAccess.EF
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LoanDbContext loanDbContext;

        public LoanRepository(LoanDbContext LoanDbContext)
        {
            this.loanDbContext = LoanDbContext ?? throw new ArgumentNullException(nameof(LoanDbContext));
        }

        public async Task<IEnumerable<Loan>> FindAll()
        {
            return await loanDbContext
               .Loans
               .Include("Rate")
               .ToListAsync();
        }

        public async Task<Loan> FindById(Guid id)
        {
            return await loanDbContext
                .Loans
                .Include("Rate")
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Loan> Add(Loan loan)
        {
            await loanDbContext.AddAsync(loan);
            await loanDbContext.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan> Update(Loan loan)
        {
            loanDbContext.Update(loan);
            await loanDbContext.SaveChangesAsync();
            return loan;
        }
    }
}
