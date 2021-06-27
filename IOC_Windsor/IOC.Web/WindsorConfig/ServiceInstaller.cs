using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IOC.Bus;
using IOC.Bus.Interfaces;
using IOC.Bus.Implement;
using Unity;
using Unity.Lifetime;
using IOC.Dal.Interfaces;
using IOC.Dal.Implement;
using log4net;

namespace IOC.Web.WindsorConfig
{
    public class ServiceInstaller : IWindsorInstaller
    {
        ILog log = LogManager.GetLogger(typeof(ControllersInstaller));
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            log.Info("Capturando as Interfaces e classes a serem resolvidas");
            var buss = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("IOC.Bus")).FirstOrDefault();
            var dal = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("IOC.Dal")).FirstOrDefault();

            var interfacesBus = buss.GetTypes().Where(x => x.Namespace == "IOC.Bus.Interfaces").ToList();
            var classesBus = buss.GetTypes().Where(x => x.Namespace == "IOC.Bus.Implement").ToList();

            var interfacesDal = dal.GetTypes().Where(x => x.Namespace == "IOC.Dal.Interfaces").ToList();
            var classesDal = dal.GetTypes().Where(x => x.Namespace == "IOC.Dal.Implement").ToList();

            log.Info("Capturou as Interfaces e classes a serem resolvidas");

            log.Info("Registrando dependencias da camada Bus");

            foreach ( Type t in interfacesBus)
            {

                var c = classesBus.Where(x => t.Name.Contains(x.Name)).FirstOrDefault() ;

                container.Register(
                     Component
                     .For(t)
                     .ImplementedBy(c)
                     .LifestyleSingleton());
            }

            log.Info("Registrou dependencias da camada Bus");

            log.Info("Registrando dependencias da camada Dal");
            foreach (Type t in interfacesDal)
            {

                var c = classesDal.Where(x => t.Name.Contains(x.Name)).FirstOrDefault();

                container.Register(
                     Component
                     .For(t)
                     .ImplementedBy(c)
                     .LifestyleSingleton());
            }

            log.Info("Registrou dependencias da camada Dal");
        }
    }
}