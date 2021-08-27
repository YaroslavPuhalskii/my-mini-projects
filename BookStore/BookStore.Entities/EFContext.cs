using System;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Entities
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("name=EFContext")
        {
        }
    }
}