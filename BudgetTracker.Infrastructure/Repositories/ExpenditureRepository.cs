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
    public class ExpenditureRepository : EfRepository<Expenditure>, IExpenditureRepository
    {
        public ExpenditureRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Expenditure> GetExpenditureById(int id)
        {
            return await _dbContext.Expenditures.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
