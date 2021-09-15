using Ninject;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using ToDoList.Core;
using ToDoList.Core.Repositories;

namespace ToDoList.WEB.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }

        public void AddBindings()
        {
            ninjectKernel.Bind<IPurposeRepo>().To<PurposeRepo>();
            ninjectKernel.Bind<IProjectRepo>().To<ProjectRepo>();
            ninjectKernel.Bind<IMissionRepo>().To<MissionRepo>();
        }
    }
}