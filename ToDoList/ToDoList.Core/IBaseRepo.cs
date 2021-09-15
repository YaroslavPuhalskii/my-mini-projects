using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.Core
{
    public interface IBaseRepo<T> where T : class
    {
        Task<T> GetById(object id);
        Task Insert(T item);
        Task Update(T item);
        Task Remove(object id);
        Task Remove(T item);
        Task<IEnumerable<T>> GetItems();
    }
}
