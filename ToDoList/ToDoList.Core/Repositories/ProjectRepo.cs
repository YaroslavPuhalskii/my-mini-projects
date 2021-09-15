using ToDoList.Entities.Models;

namespace ToDoList.Core.Repositories
{
    public class ProjectRepo : BaseRepo<Project>, IProjectRepo
    {
        public ProjectRepo() { }
    }
}
