using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Loans.Domain.Loans
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> FindAll();
        Task<Loan> FindById(Guid id);
        Task<Loan> Add(Loan loan);
        Task<Loan> Update(Loan loan);
    }
}
