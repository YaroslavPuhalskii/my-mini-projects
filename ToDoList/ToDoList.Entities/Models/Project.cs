using System;
using System.Collections.Generic;

namespace ToDoList.Entities.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ProjectStart { get; set; }
        public DateTime ProjectFinish { get; set; }
        public ICollection<Mission> Missions { get; set; }
    }
}
