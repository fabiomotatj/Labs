using IOC.Ent;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dal
{
    public class DataContext: DbContext
    {
        public DataContext()
           : base("SqlConn")
        {
            Database.SetInitializer<DataContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var defaultSchema = "dbo";
            if (!string.IsNullOrWhiteSpace(defaultSchema))
            {
                modelBuilder.HasDefaultSchema(defaultSchema);
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UsuarioEnt> Usuario { get; set; }
    }
}
