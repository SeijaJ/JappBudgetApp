using BudgetApp.Interfaces.Interfaces_Repositories;
using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(JappCoreDBSQLContext dbContext) : base(dbContext) 
        {

        }
    }
}
