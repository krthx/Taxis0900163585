using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Taxis0900163585.Models;

namespace Taxis0900163585.Data
{
    class TaxisContextMigration : DbContext
    {
        public static int RequiredDatabaseVersion = 1;

        public DbSet<Conductor> Conductores { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Viaje> Viajes { get; set; }

        public DbSet<SchemaInfo> SchemaInfoes { get; set; }


        public TaxisContextMigration()
            : base("name=TaxisContextMigration")
        {
            // the terrible hack
            //var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;  
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public void Initialize()
        {
            using (TaxisContextMigration courseraContext = new TaxisContextMigration())
            {
                int currentVersion = 0;
                if (courseraContext.SchemaInfoes.Count() > 0)
                    currentVersion = courseraContext.SchemaInfoes.Max(x => x.Version);
                TaxisContextHelper mmSqliteHelper = new TaxisContextHelper();
                while (currentVersion < RequiredDatabaseVersion)
                {
                    currentVersion++;
                    foreach (string migration in mmSqliteHelper.Migrations[currentVersion])
                    {
                        courseraContext.Database.ExecuteSqlCommand(migration);
                    }
                    courseraContext.SchemaInfoes.Add(new SchemaInfo() { Version = currentVersion });
                    courseraContext.SaveChanges();
                }
            }

        }
    }
}