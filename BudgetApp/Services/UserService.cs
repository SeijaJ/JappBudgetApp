using BudgetApp.Interfaces.Interfaces_Repositories;
using BudgetApp.Interfaces.Interfaces_Services;
using BudgetApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IBaseRepository<User> baseRepo, IUserRepository userRepo) : base(baseRepo)
        {
            _userRepo = userRepo;
        }
    }
}
