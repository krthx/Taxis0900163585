using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Taxis0900163585.Models;

namespace Taxis0900163585.Source
{
    internal class TaxisContext : DbContext
    {
        public static int RequiredDatabaseVersion = 1;
 
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<SchemaInfo> SchemaInfoes { get; set; }

        public void Initialize()
        {
            using (TaxisContext taxisContext = new TaxisContext())
            {
                int currentVersion = 0;
                if (taxisContext.SchemaInfoes.Count() > 0)
                    currentVersion = taxisContext.SchemaInfoes.Max(x => x.Version);
                TaxisContextHelper mmSqliteHelper = new TaxisContextHelper();
                while (currentVersion < RequiredDatabaseVersion)
                {
                    currentVersion++;
                    foreach (string migration in mmSqliteHelper.Migrations[currentVersion])
                    {
                        taxisContext.Database.ExecuteSqlCommand(migration);
                    }
                    taxisContext.SchemaInfoes.Add(new SchemaInfo() { Version = currentVersion });
                    taxisContext.SaveChanges();
                }
            }

        }
    }

    class TaxisContextHelper
    {
        public TaxisContextHelper()
        {
            Migrations = new Dictionary<int, IList>();

            MigrationVersion1();
        }

        public Dictionary<int, IList> Migrations { get; set; }

        private void MigrationVersion1()
        {
            IList steps = new ArrayList();

            steps.Add("CREATE TABLE \"Usuario\" (\"Id\" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , \"Nombre\" TEXT, \"Correo\" TEXT, \"Contrasena\" TEXT, \"Puntuado\" TEXT)");
            steps.Add("CREATE TABLE \"Conductor\" (\"Id\" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , \"Nombre\" TEXT, \"Correo\" TEXT, \"Contrasena\" TEXT)");
            steps.Add("CREATE TABLE \"Viaje\" (\"IdConductor\" INTEGER , \"IdUsuario\" INTEGER , \"Destino\" TEXT, \"Ubicacion\" TEXT, \"Tarifa\" TEXT, \"Puntuado\" TEXT)");

            Migrations.Add(1, steps);
        }
    }
}