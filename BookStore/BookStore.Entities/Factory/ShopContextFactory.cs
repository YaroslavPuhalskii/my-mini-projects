using BookStore.Entities.Abstract;
using System.Data.Entity;

namespace BookStore.Entities.Factory
{
    public class ShopContextFactory : IShopContextFactory
    {
        public DbContext GetContext()
        {
            return new EFContext();
        }
    }
}
