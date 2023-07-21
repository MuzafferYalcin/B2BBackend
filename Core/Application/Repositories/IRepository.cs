using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IRepository<T> where T : class, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
    }
}
