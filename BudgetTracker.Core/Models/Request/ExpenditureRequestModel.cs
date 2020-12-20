using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetTracker.Core.Models.Request
{
    public class ExpenditureRequestModel
    {
        [Required]
        public decimal Amount { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        [StringLength(50)]
        public string Remarks { get; set; }
    }
}
