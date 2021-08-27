using BookStore.Entities.Models;

namespace BookStore.Core.Repositories
{
    public class ManagerRepo : BaseRepo<Manager>, IManagerRepo
    {
        public ManagerRepo()
        { }
    }
}
