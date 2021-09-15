using System.Data.Entity;

namespace ToDoList.Entities.Abstract
{
    public interface IContextFactory
    {
        DbContext GetContext();
    }
}
