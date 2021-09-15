using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDoList.WEB.Startup))]
namespace ToDoList.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
