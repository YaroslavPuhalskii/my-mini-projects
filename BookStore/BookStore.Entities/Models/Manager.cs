using System.Collections.Generic;

namespace BookStore.Entities.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
