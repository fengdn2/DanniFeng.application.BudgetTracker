using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetTracker.Core.Models.Request
{
    public class UserRequestModel
    {
        public string Fullname { get; set; }
        [Required]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        
    }
}
