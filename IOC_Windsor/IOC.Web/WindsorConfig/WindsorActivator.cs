using System;
using System.Collections.Generic;
using System.Linq;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(IOC.Web.WindsorConfig.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof(IOC.Web.WindsorConfig.WindsorActivator), "Shutdown")]

namespace IOC.Web.WindsorConfig
{
    public class WindsorActivator
    {
        static ContainerBootstrapper bootstrapper;

        public static void PreStart()
        {
            bootstrapper = ContainerBootstrapper.Bootstrap();
        }

        public static void Shutdown()
        {
            if (bootstrapper != null)
                bootstrapper.Dispose();
        }
    }
}