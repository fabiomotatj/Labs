using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreApiIOC.Dal
{
    public class DIContainer
    {
        public static void ConfigureDI(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ModelDev")));

            services.AddSingleton<IConfiguration>(Configuration);
        }
    }
}
