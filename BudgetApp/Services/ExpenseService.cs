using BudgetApp.Interfaces.Interfaces_Repositories;
using BudgetApp.Interfaces.Interfaces_Services;
using BudgetApp.Models;
using BudgetApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Services
{
    public class ExpenseService: BaseService<Expense>, IExpenseService
    {
        private readonly IExpenseRepository _expenseRepo;

        public ExpenseService(IBaseRepository<Expense> baseRepo, IExpenseRepository expenseRepo): base(baseRepo)
        {
            _expenseRepo = expenseRepo;
        }


        /// <summary>
        /// Method to search for all expenses for a month and year, and converting it to a DTO model.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="searchMonth"> Userinput for specific month to search for </param>
        /// <param name="searchYear"> Userinput for the year to search in </param>
        /// <returns> A list of the expenses for the month, including the names of payees and converted to the DTO model</returns>
        /// 

        public async Task<IEnumerable<ExpenseDTO>> GetMonthlyExpenseWithPayeeAsync(Guid userId, int searchMonth, int searchYear)
        {
            var results = await _expenseRepo.GetMonthlyExpenseWithPayeeAsync(userId, searchMonth, searchYear);

            List<ExpenseDTO> monthlyExpensesDTO = new List<ExpenseDTO>();

            foreach(var result in results)
            {
                monthlyExpensesDTO.Add(new ExpenseDTO
                {
                    ExpenseId = result.ExpenseId,
                    ExpenseMonth = result.ExpenseMonth,
                    ExpenseYear = result.ExpenseYear,
                    ExpenseAmount = result.ExpenseAmount,
                    UserId = result.UserId,
                    PayeeName = result.Payee.PayeeName
                });
            }

            return monthlyExpensesDTO;
        }
    }
}
