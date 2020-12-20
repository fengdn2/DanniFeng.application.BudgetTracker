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
    public class ExpenditureService : IExpenditureService
    {
        private readonly IExpenditureRepository _expenditureRepository;

        public ExpenditureService(IExpenditureRepository expenditureRepository)
        {
            _expenditureRepository = expenditureRepository;
        }
        public async Task<ExpenditureResponseModel> AddExpenditure(ExpenditureRequestModel requestModel, int id)
        {
            var expenditure = new Expenditure
            {
                UserId = id,
                Amount = requestModel.Amount,
                Description = requestModel.Description,
                ExpDate = requestModel.Date,
                Remarks = requestModel.Remarks
            };
            var createdExpenditure = await _expenditureRepository.AddAsync(expenditure);
            var response = new ExpenditureResponseModel
            {
                Id = createdExpenditure.Id,
                Amount = createdExpenditure.Amount,
                Description = createdExpenditure.Description,
                Date = createdExpenditure.ExpDate,
                Remarks = createdExpenditure.Remarks
            };
            return response;
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditures()
        {
            var expenditures = await _expenditureRepository.ListAllAsync();

            var expenditureResponseModel = new List<ExpenditureResponseModel>();
            foreach (var expenditure in expenditures)
            {
                expenditureResponseModel.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    Date = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }
            return expenditureResponseModel;
        }

        public async Task DeleteExpenditure(int expenditureId)
        {
            var expenditure = await _expenditureRepository.GetExpenditureById(expenditureId);
            await _expenditureRepository.DeleteAsync(expenditure);
        }

        public async Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel requestModel, int uid, int expenditureId)
        {
            var expenditure = new Expenditure
            {
                Id = expenditureId,
                UserId = uid,
                Amount = requestModel.Amount,
                Description = requestModel.Description,
                ExpDate = requestModel.Date,
                Remarks = requestModel.Remarks
            };
            var updatedExpenditure = await _expenditureRepository.UpdateAsync(expenditure);
            var response = new ExpenditureResponseModel
            {
                Id = updatedExpenditure.Id,
                Amount = updatedExpenditure.Amount,
                Description = updatedExpenditure.Description,
                Date = updatedExpenditure.ExpDate,
                Remarks = updatedExpenditure.Remarks
            };
            return response;
        }
    }
}
