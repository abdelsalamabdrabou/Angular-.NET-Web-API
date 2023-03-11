using System.Linq.Expressions;
using WebTask.Core.Entities;

namespace WebTask.Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        void Delete(T entity);
        Task<T> Get(int id, Expression<Func<T, bool>>? filter = null, string? navigationProperety = null);
        Task<IList<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? navigationProperety = null);
        void Update(T entity);
        Task SaveContext();
    }
}
