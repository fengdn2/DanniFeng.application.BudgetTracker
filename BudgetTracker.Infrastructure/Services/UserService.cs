using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using BudgetTracker.Core.RepositoryInterfaces;
using BudgetTracker.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BudgetTracker.Core.Models.Response.AccountDetailResponseModel;

namespace BudgetTracker.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenditureRepository _expenditureRepository;

        public UserService(IUserRepository userRepository, IIncomeRepository incomeRepository, IExpenditureRepository expenditureRepository)
        {
            _userRepository = userRepository;
            _incomeRepository = incomeRepository;
            _expenditureRepository = expenditureRepository;
        }

        public async Task<UserListResponseModel> CreateUser(UserRequestModel requestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);

            if (dbUser != null && string.Equals(dbUser.Email, requestModel.Email, StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Email Already Exits");

            var user = new User
            {
                Email = requestModel.Email,
                Password = requestModel.Password,
                Fullname = requestModel.Fullname
            };
            var createdUser = await _userRepository.AddAsync(user);
            var response = new UserListResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                Fullname = createdUser.Fullname
            };
            return response;
        }

        public async Task<AccountDetailResponseModel> GetAccountDetailById(int id)
        {
            var accountDetail = await _userRepository.GetUserById(id);

            var accountResponseModel = new AccountDetailResponseModel
            {
                Id = id,
                Fullname = accountDetail.Fullname,
                Email = accountDetail.Email,
                TotalIncome = accountDetail.Incomes.Sum(u => u.Amount),
                TotalExpense = accountDetail.Expenditures.Sum(u => u.Amount),
            };

            accountResponseModel.Incomes = new List<AccountIncomeResponseModel>();
            foreach (var income in accountDetail.Incomes)
            {
                accountResponseModel.Incomes.Add(new AccountIncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    Date = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }
            accountResponseModel.Expenditures = new List<AccountExpenseResponseModel>();
            foreach (var expenditure in accountDetail.Expenditures)
            {
                accountResponseModel.Expenditures.Add(new AccountExpenseResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    Date = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }

            return accountResponseModel;

        }

        public async Task<IEnumerable<UserListResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();

            var userResponseModel = new List<UserListResponseModel>();
            foreach (var user in users)
            {
                userResponseModel.Add(new UserListResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Fullname = user.Fullname,
                    TotalIncome = user.Incomes.Sum(i => i.Amount),
                    TotalExpense = user.Expenditures.Sum(e => e.Amount)
                });
            }
            return userResponseModel;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);

           
            foreach (var income in user.Incomes)
            {
                await _incomeRepository.DeleteAsync(income);
            }
            foreach (var expenditure in user.Expenditures)
            {
                await _expenditureRepository.DeleteAsync(expenditure);
            }
            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserListResponseModel> UpdateUser(UserRequestModel requestModel, int id)
        {
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);

            if (dbUser != null && string.Equals(dbUser.Email, requestModel.Email, StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Email Already Exits");

            var user = new User
            {
                Id = id,
                JoinedOn = DateTime.Now,
                Fullname = requestModel.Fullname,
                Password = requestModel.Password,
                Email = requestModel.Email
            };

            var updatedUser = await _userRepository.UpdateAsync(user);
            var response = new UserListResponseModel
            {
                Id = updatedUser.Id,
                Email = updatedUser.Email,
                Fullname = updatedUser.Fullname
            };
            return response;
        }
    }
}
