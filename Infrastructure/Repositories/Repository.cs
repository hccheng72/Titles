using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TitlesContext _dbContext;
        public Repository(TitlesContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity); //save in memory
            await _dbContext.SaveChangesAsync(); // save out memory
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            var d = await _dbContext.Set<T>().FindAsync(id);
            if (d != null)
            {
                _dbContext.Set<T>().Remove(d);
                await _dbContext.SaveChangesAsync();
                return d;
            }
            return null;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        //public async Task<List<T>> GetByName(Func<T, bool> predicate)
        //{
        //    return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        //}

        public async Task<T> Update(T entity)
        {
            if (_dbContext.Set<T>().Update(entity) != null)
            {
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}
