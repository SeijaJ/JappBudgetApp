using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BudgetApp.Models
{
    public partial class Expense
    {
        public Guid ExpenseId { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Month value can only be between 1 and 12")]
        public int ExpenseMonth { get; set; }

        [Required]
        [Range(2000, 2999, ErrorMessage = "Year value can't be less than 2000 and or more than 2999")]
        public int ExpenseYear { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount can't be a negativ number")]
        public decimal ExpenseAmount { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid PayeeId { get; set; }

        public virtual Payee Payee { get; set; }
        public virtual User User { get; set; }
    }
}
