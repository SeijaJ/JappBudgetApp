using BudgetApp.Interfaces.Interfaces_Repositories;
using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Repositories
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        private readonly JappCoreDBSQLContext _dbContext;
        public ExpenseRepository(JappCoreDBSQLContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Expense>> GetMonthlyExpenseWithPayeeAsync(Guid userId, int searchMonth, int searchYear)
        {
            var monthlyExpenses = await _dbContext.Expenses.Include(e => e.Payee)
                .Include(e => e.User)
                .Where(e => e.UserId == userId && e.ExpenseYear == searchYear && e.ExpenseMonth == searchMonth)
                .ToListAsync();

            return monthlyExpenses;
        }
    }
}
