using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BudgetApp.Models
{
    public partial class Payee
    {
        public Payee()
        {
            Expenses = new HashSet<Expense>();
        }

        public Guid PayeeId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters long")]
        public string PayeeName { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
