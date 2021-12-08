using BudgetApp.Interfaces.Interfaces_Repositories;
using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly JappCoreDBSQLContext _dbContext;

        public BaseRepository(JappCoreDBSQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            try
            {
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not save {nameof(entity)}, error: {ex.Message}");
            }
        }

        public async Task<TEntity> Delete(TEntity entity, Guid id)
        {
            try
            {
                var exist = await _dbContext.Set<TEntity>().FindAsync(id);
                _dbContext.Set<TEntity>().Remove(exist);

                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not delete {nameof(entity)}, error: {ex.Message}");
            }
        }

        public async Task<TEntity> Get(Guid id)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not get entity with ID: {id}, error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await _dbContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve enteties of {ex.Message}");
            }
        }

        public async Task<TEntity> Update(TEntity entity, Guid id)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not update {nameof(entity)}, error: {ex.Message}");
            }
        }
    }
}
