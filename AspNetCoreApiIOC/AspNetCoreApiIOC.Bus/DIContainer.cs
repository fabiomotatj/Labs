using AspNetCoreApiIOC.Dal;
using AspNetCoreApiIOC.Dal.Implement;
using AspNetCoreApiIOC.Dal.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreApiIOC.Bus
{
    public class DIContainer
    {
        public static void ConfigureDI(IServiceCollection services, IConfiguration Configuration)
        {
            AspNetCoreApiIOC.Dal.DIContainer.ConfigureDI(services, Configuration);

            services.AddScoped<IUsuarioDal, UsuarioDal>();

            services.AddSingleton<IConfiguration>(Configuration);
        }
    }
}
