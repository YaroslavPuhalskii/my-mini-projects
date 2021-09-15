using System;

namespace ToDoList.Entities.Models
{
    public class Mission
    {
        public int MissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime MissionStart { get; set; }
        public DateTime MissionFinish { get; set; }
    }
}
