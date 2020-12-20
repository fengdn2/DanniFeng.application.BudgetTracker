using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.Models.Response
{
    public class IncomeResponseModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }
    }
}
