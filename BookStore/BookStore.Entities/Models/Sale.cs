using System;

namespace BookStore.Entities.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        public int? ClientId { get; set; }
        public virtual Client Client { get; set;}

        public int? ManagerId { get; set; }
        public virtual Manager Manager { get; set; }

        public int? BookId { get; set; }
        public virtual Book Book { get; set; }

        public DateTime DateTime { get; set; }
        public decimal Price { get; set; }
    }
}
