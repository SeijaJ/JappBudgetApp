using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Interfaces.Interfaces_Repositories
{
    public interface IBaseRepository<TEntity>: IBaseMethodsServiceRepository<TEntity> where TEntity : class
    {
    }
}
