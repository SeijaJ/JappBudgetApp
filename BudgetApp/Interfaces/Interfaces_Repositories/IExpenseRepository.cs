using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Interfaces.Interfaces_Repositories
{
    public interface IExpenseRepository: IBaseRepository<Expense>
    {
        Task<IEnumerable<Expense>> GetMonthlyExpenseWithPayeeAsync(Guid userId, int searchMonth, int searchYear);

    }
}
