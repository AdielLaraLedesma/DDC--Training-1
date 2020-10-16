using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Aplicacion.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base(new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString), true)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }
       
        public DbSet<Institucion> Instituciones { set; get; }
        public DbSet<Tarjeta> Tarjetas { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Tarjeta>().HasRequired(x => x.Institucion);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties().Configure(p => {
                p.HasColumnName
                (p.ClrPropertyInfo.Name.ToUpper());
            });

            SqlConnectionStringBuilder sqlB = new SqlConnectionStringBuilder(Database.Connection.ConnectionString);

            modelBuilder.HasDefaultSchema(sqlB.UserID);
        }
    }
}