using TemplateMVC.Ent;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMVC.Dal
{
    public class DataContext: DbContext
    {
        public DataContext()
            : base("DefaultDev")
        {
            Database.SetInitializer<DataContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var defaultSchema = "academia";
            if (!string.IsNullOrWhiteSpace(defaultSchema))
            {
                modelBuilder.HasDefaultSchema(defaultSchema);
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UsuarioEnt> Usuario { get; set; }
    }
}
