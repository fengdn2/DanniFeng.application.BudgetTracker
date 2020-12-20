using BudgetTracker.Core.Entities;
using BudgetTracker.Core.RepositoryInterfaces;
using BudgetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastructure.Repositories
{
    public class IncomeRepository : EfRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Income> GetIncomeById(int id)
        {
            return await _dbContext.Incomes.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
