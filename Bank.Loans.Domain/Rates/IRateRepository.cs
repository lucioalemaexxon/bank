using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Loans.Domain.Rates
{
    public interface IRateRepository
    {
        Task<IEnumerable<Rate>> FindAll();
        Task<Rate> FindById(Guid id);
        Task<Rate> Add(Rate rate);
        Task Delete(Guid id);
    }
}
