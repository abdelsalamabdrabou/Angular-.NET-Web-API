using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebTask.Core.Entities;
using WebTask.Infrastructure.Context;

namespace WebTask.Infrastructure.Repository
{
    public class GenericRepoistory<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> dbSet;
        public GenericRepoistory(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<T> Get(int id, Expression<Func<T, bool>>? filter = null, string? navigationProperety = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            if (navigationProperety != null)
                query = query.Include(navigationProperety);

            if (filter != null)
                query = query.Where(filter);            

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? navigationProperety = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            if (navigationProperety != null)
                query = query.Include(navigationProperety);

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task SaveContext()
        {
           await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
