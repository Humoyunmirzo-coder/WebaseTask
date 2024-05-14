using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ConpanyDbContext _conpanyDbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ConpanyDbContext conpanyDbContext)
        {
            _conpanyDbContext = conpanyDbContext;
        }

        public async  Task<T> CreateAsync(T entity)
        {
            await _conpanyDbContext.AddAsync(entity);
            await _conpanyDbContext.SaveChangesAsync();
            return entity;
        }

        public async  Task<bool> DeleteAsync(int Id)
        {
            var entity = await _conpanyDbContext.Set<T>().FirstOrDefaultAsync();
            if (entity == null)
            {
                return false;
            }

            _conpanyDbContext.Remove(entity);
            await _conpanyDbContext.SaveChangesAsync();
            return true;
        }

        public async  Task<IEnumerable<T>> GetAllAsync()
        {
            return await _conpanyDbContext.Set<T>().ToListAsync();
        }

        public async  Task<T> GetByIdAsync(int id)
        {
            return await _conpanyDbContext.Set<T>().FindAsync(id);
        }

        public async  Task<bool> UpdateAsync(T entity)
        {
            _conpanyDbContext.Entry(entity).State = EntityState.Modified;
            await _conpanyDbContext.SaveChangesAsync();
            return true;
        }
    }
}
