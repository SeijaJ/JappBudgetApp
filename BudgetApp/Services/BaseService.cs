using BudgetApp.Interfaces.Interfaces_Repositories;
using BudgetApp.Interfaces.Interfaces_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepo;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepo = baseRepository;
        }

        // Add
        public async Task<TEntity> Add(TEntity entity)
        {
            return await _baseRepo.Add(entity);
        }

        // Delete
        public async Task<TEntity> Delete(TEntity entity, Guid id)
        {
            await _baseRepo.Delete(entity, id);
            return entity;
        }

        // Get
        public async Task<TEntity> Get(Guid id)
        {
            return await _baseRepo.Get(id);
        }

        // GetAll
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _baseRepo.GetAll();
        }

        // Update
        public async Task<TEntity> Update(TEntity entity, Guid id)
        {
            await _baseRepo.Update(entity, id);
            return entity;
        }
    }
}
