using System.Web.Mvc;  
using Castle.MicroKernel.Registration;  
using Castle.MicroKernel.SubSystems.Configuration;  
using Castle.Windsor;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using log4net;

namespace IOC.Web.WindsorConfig
{
    public class ControllersInstaller : IWindsorInstaller
    {
        ILog log = LogManager.GetLogger(typeof(ControllersInstaller));
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            log.Info("Registrando Controladores MVC");
            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IController>().
                    If(c => c.Name.EndsWith("Controller")).
                    LifestyleTransient());

            log.Info("Registrando Controladores WebApi");
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