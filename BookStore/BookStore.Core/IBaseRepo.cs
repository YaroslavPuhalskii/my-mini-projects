using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public interface IBaseRepo<T> where T : class
    {
        Task Insert(T entity);
        Task Delete(T entity);
        Task Delete(object id);
        Task Update(T entity);

        Task<T> GetById(object id);
        Task<IEnumerable<T>> GetItems();
    }
}
