using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Models.DTOs
{
    public class ExpenseDTO
    {
        public Guid ExpenseId { get; set; }

        public int ExpenseMonth { get; set; }

        public int ExpenseYear { get; set; }

        public decimal ExpenseAmount { get; set; }

        public Guid UserId { get; set; }

        public string PayeeName { get; set; }

    }
}
