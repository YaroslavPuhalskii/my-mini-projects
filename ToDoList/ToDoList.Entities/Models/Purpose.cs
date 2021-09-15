using System.Collections.Generic;

namespace ToDoList.Entities.Models
{
    public class Purpose
    {
        public int PurposeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
