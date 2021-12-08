using BudgetApp.Interfaces.Interfaces_Services;
using BudgetApp.Models;
using BudgetApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {

        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET: api/<ExpenseController>
        [HttpGet]
        public async Task<IEnumerable<Expense>> GetExpense()
        {
            return await _expenseService.GetAll();
        }

        // GET api/<ExpenseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(Guid id)
        {
            var expense = await _expenseService.Get(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        // POST api/<ExpenseController>
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            return await _expenseService.Add(expense);
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Expense>> PutExpense(Expense expense, Guid id)
        {
            return await _expenseService.Update(expense, id);
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expense>> DeleteExpense(Expense expense, Guid id)
        {
            return await _expenseService.Delete(expense, id);
        }


        [HttpGet("{searchMonth}/{searchYear}")]

        public async Task<IEnumerable<ExpenseDTO>> GetGetMonthlyExpenseWithPayeeAsync(Guid userId, int searchMonth, int searchYear)
        {
            var monthlyExpenses = await _expenseService.GetMonthlyExpenseWithPayeeAsync(userId, searchMonth, searchYear);

            if (monthlyExpenses == null)
            {
                return (IEnumerable<ExpenseDTO>)NotFound();
            }

            return monthlyExpenses;
        }
    }
}
