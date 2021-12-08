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

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _baseRepo.AddAsync(entity);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, Guid id)
        {
            await _baseRepo.DeleteAsync(entity, id);
            return entity;
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _baseRepo.GetAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _baseRepo.GetAllAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, Guid id)
        {
            await _baseRepo.UpdateAsync(entity, id);
            return entity;
        }
    }
}
