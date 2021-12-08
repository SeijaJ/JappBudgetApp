using BudgetApp.Interfaces.Interfaces_Services;
using BudgetApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService budgetService)
        {
            _userService = budgetService;
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _userService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            return await _userService.Add(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(User user, Guid id)
        {
            return await _userService.Update(user, id);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(User user, Guid id)
        {
            return await _userService.Delete(user, id);
        }
    }
}
