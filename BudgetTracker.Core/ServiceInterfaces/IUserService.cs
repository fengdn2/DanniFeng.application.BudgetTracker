using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core.ServiceInterfaces
{
    public interface IUserService
    {

        Task<AccountDetailResponseModel> GetAccountDetailById(int id);
        Task<UserListResponseModel> CreateUser(UserRequestModel requestModel);
        Task<UserListResponseModel> UpdateUser(UserRequestModel requestModel, int id);
        Task<IEnumerable<UserListResponseModel>> GetAllUsers();
        Task DeleteUser(int id);
    }
}
