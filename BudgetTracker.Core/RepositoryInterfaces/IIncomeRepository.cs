using BudgetTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.RepositoryInterfaces
{
    public interface IIncomeRepository : IAsyncRepository<Income>
    {
        Task<Income> GetIncomeById(int id);
    }
}
