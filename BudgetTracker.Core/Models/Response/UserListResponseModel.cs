using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.Models.Response
{
    public class UserListResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
    }
}
