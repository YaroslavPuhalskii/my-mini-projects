using System.Data.Entity;
using ToDoList.Entities.Abstract;

namespace ToDoList.Entities.Factory
{
    public class ContextFactory : IContextFactory
    {
        public DbContext GetContext()
        {
            return new EFContext();
        }
    }
}
