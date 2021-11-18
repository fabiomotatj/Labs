using AspNetCoreApiIOC.Ent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreApiIOC.Dal
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<UsuarioEnt> Usuario { get; set; }
        public DbSet<SistemaEnt> Sistema { get; set; }
        public DbSet<PerfilEnt> Perfil { get; set; }
        public DbSet<SistemaPerfilEnt> SistemaPerfil { get; set; }
    }
}
