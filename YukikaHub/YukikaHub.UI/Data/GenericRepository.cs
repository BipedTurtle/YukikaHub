using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.UI.Data
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        public TContext _context;
        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity model)
        {
            _context.Set<TEntity>().Add(model);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await
                _context.Set<TEntity>()
                        .ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllNoTrackingAsync()
        {
            return await
                _context.Set<TEntity>()
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await
                _context.Set<TEntity>()
                        .FindAsync(id);
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Remove(TEntity model)
        {
            _context.Set<TEntity>().Remove(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SetState(TEntity entity, EntityState entityState)
        {
            _context.Entry<TEntity>(entity).State = entityState;
        }
    }
}
