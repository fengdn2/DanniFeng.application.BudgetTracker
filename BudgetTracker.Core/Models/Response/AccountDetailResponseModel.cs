using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.Models.Response
{
    public class AccountDetailResponseModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public List<AccountIncomeResponseModel> Incomes { get; set; }
        public List<AccountExpenseResponseModel> Expenditures { get; set; }

        public class AccountIncomeResponseModel
        {
            public int Id { get; set; }
            public int? UserId { get; set; }
            public decimal Amount { get; set; }
            public string Description { get; set; }
            public DateTime? Date { get; set; }
            public string Remarks { get; set; }
        }

        public class AccountExpenseResponseModel
        {
            public int Id { get; set; }
            public int? UserId { get; set; }
            public decimal Amount { get; set; }
            public string Description { get; set; }
            public DateTime? Date { get; set; }
            public string Remarks { get; set; }
        }
    }
}
