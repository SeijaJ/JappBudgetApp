using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Interfaces
{
    public interface IBaseMethodsServiceRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(Guid id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity, Guid id);
        Task<TEntity> Delete(TEntity entity, Guid id);
    }
}
