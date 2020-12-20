using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterfaces
{
    public interface IIncomeService
    {
        Task<IncomeResponseModel> AddIncome(IncomeRequestModel requestModel, int userId);

        Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel requestModel, int uid, int incomeid);
        Task DeleteIncome(int incomeId);
        Task<IEnumerable<IncomeResponseModel>> GetAllIncomes();

        
    }
}
