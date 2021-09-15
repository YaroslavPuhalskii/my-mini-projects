using System.Data.Entity;
using ToDoList.Entities.Models;

namespace ToDoList.Entities
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("name=EFContext")
        {
        }

        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Mission> Missions { get; set; }
    }
}