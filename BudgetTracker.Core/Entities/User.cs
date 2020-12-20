using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetTracker.Core.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }

        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expenditure> Expenditures { get; set; }
    }
}
