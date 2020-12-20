using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterfaces
{
    public interface IExpenditureService
    {
        Task<ExpenditureResponseModel> AddExpenditure(ExpenditureRequestModel requestModel, int id);
        Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel requestModel, int uid, int expenditureId);
        Task DeleteExpenditure(int expenditureId);
        Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditures();

        
    }

}
