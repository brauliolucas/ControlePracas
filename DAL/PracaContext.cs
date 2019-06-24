using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ControlePracas.Models;

namespace ControlePracas.DAL
{
    public class PracaContext : DbContext
    {
        public PracaContext() : base("PracaContext")
        {
        }

        public DbSet<Praca> Pracas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}