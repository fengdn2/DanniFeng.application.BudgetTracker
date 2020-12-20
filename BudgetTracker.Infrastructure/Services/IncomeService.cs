using BudgetTracker.Core.Entities;
using BudgetTracker.Core.Models.Request;
using BudgetTracker.Core.Models.Response;
using BudgetTracker.Core.RepositoryInterfaces;
using BudgetTracker.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastructure.Services
{
    
        public class IncomeService : IIncomeService
        {
            private readonly IIncomeRepository _incomeRepository;

            public IncomeService(IIncomeRepository incomeRepository)
            {
                _incomeRepository = incomeRepository;
            }

            public async Task<IncomeResponseModel> AddIncome(IncomeRequestModel requestModel, int userId)
            {
                var income = new Income
                {
                    UserId = userId,
                    Amount = requestModel.Amount,
                    Description = requestModel.Description,
                    IncomeDate = requestModel.Date,
                    Remarks = requestModel.Remarks
                };
                var createdIncome = await _incomeRepository.AddAsync(income);
                var response = new IncomeResponseModel
                {
                    Id = createdIncome.Id,
                    Amount = createdIncome.Amount,
                    Description = createdIncome.Description,
                    Date = createdIncome.IncomeDate,
                    Remarks = createdIncome.Remarks
                };
                return response;
            }

            public async Task<IEnumerable<IncomeResponseModel>> GetAllIncomes()
            {
                var incomes = await _incomeRepository.ListAllAsync();

                var incomeResponseModel = new List<IncomeResponseModel>();
                foreach (var income in incomes)
                {
                    incomeResponseModel.Add(new IncomeResponseModel
                    {
                        Id = income.Id,
                        Amount = income.Amount,
                        Description = income.Description,
                        Date = income.IncomeDate,
                        Remarks = income.Remarks
                    });
                }
                return incomeResponseModel;
            }

            public async Task DeleteIncome(int incomeId)
            {
                var income = await _incomeRepository.GetIncomeById(incomeId);
                await _incomeRepository.DeleteAsync(income);
            }

            public async Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel requestModel, int uid, int incomeid)
            {
                var income = new Income
                {
                    Id = incomeid,
                    UserId = uid,
                    Amount = requestModel.Amount,
                    Description = requestModel.Description,
                    IncomeDate = requestModel.Date,
                    Remarks = requestModel.Remarks
                };
                var updatedIncome = await _incomeRepository.UpdateAsync(income);
                var response = new IncomeResponseModel
                {
                    Id = updatedIncome.Id,
                    Amount = updatedIncome.Amount,
                    Description = updatedIncome.Description,
                    Date = updatedIncome.IncomeDate,
                    Remarks = updatedIncome.Remarks
                };
                return response;
            }
        }
    
}
