using System.Data.Entity;

namespace BookStore.Entities.Abstract
{
    public interface IShopContextFactory
    {
        DbContext GetContext();
    }
}
