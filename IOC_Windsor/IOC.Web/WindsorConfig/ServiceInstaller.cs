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

namespace IOC.Web.WindsorConfig
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                 Component
                 .For<IUsuarioBus>()
                 .ImplementedBy<UsuarioBus>()
                 .LifestyleSingleton());

            container.Register(
                 Component
                 .For<IUsuarioDal>()
                 .ImplementedBy<UsuarioDal>()
                 .LifestyleSingleton());


        }
    }
}