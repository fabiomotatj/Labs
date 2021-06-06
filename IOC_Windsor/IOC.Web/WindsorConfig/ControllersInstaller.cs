using System.Web.Mvc;  
using Castle.MicroKernel.Registration;  
using Castle.MicroKernel.SubSystems.Configuration;  
using Castle.Windsor;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace IOC.Web.WindsorConfig
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());

            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IHttpController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());

            GlobalConfiguration.Configuration.DependencyResolver = new DependencyResolver(container.Kernel);

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}