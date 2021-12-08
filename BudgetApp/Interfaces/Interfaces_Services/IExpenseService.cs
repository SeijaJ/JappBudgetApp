using BudgetApp.Models;
using BudgetApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Interfaces.Interfaces_Services
{
    public interface IExpenseService: IBaseService<Expense>
    {
        Task<IEnumerable<ExpenseDTO>> GetMonthlyExpenseWithPayeeAsync(Guid userId, int searchMonth, int searchYear);
    }
}
