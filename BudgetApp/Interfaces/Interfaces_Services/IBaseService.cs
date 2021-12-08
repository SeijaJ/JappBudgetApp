using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Interfaces.Interfaces_Services
{
    public interface IBaseService<TEntity> : IBaseMethodsServiceRepository<TEntity> where TEntity : class
    {
    }
}
