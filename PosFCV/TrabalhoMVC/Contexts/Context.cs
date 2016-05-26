using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoMVC.Models;

namespace TrabalhoMVC.Contexts
{
    public class Context : DbContext
    {
        public Context() : base()
        {
        }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>().HasRequired(c => c.Estado).WithMany(c => c.Cidades).HasForeignKey(fk => fk.CodigoEstado).WillCascadeOnDelete(false);
        }
    }
}
