using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ABDALLAH.Data.Base;

namespace ABDALLAH.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseReprository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }
        async Task IEntityBaseReprository<T>.AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        async Task IEntityBaseReprository<T>.DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.ID == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        async Task<IEnumerable<T>> IEntityBaseReprository<T>.GetAllAsync() => await _context.Set<T>().ToListAsync();
        async Task<IEnumerable<T>> IEntityBaseReprository<T>.GetAllAsync(params Expression<Func<T, object>>[] includeproperties)
        {
            IQueryable<T> quary = _context.Set<T>();
            quary = includeproperties.Aggregate(quary, (current, includeproperty) => current.Include(includeproperty));
            return await quary.ToListAsync();
        }
        async Task<T> IEntityBaseReprository<T>.GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.ID == id);
        async Task IEntityBaseReprository<T>.UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
