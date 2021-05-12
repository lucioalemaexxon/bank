using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.Loans.Domain.Fees
{
    public interface IFeeRepository
    {
        Task<IEnumerable<Fee>> FindAll();
        Task<Fee> FindById(Guid id);
        Task<Fee> Add(Fee fee);
        Task Delete(Guid id);
    }
}
