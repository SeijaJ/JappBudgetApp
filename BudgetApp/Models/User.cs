using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BudgetApp.Models
{
    public partial class User
    {
        public User()
        {
            Expenses = new HashSet<Expense>();
        }

        public Guid UserId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters long")]
        public string UserFirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 20 characters long")]
        public string UserLastName { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
