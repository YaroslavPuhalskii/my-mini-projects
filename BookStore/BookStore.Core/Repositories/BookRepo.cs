using BookStore.Entities.Models;

namespace BookStore.Core.Repositories
{
    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        public BookRepo()
        { }
    }
}
