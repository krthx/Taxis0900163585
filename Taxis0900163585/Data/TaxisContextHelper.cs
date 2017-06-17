using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxis0900163585.Data
{
    class TaxisContextHelper
    {
        public TaxisContextHelper()
        {
            Migrations = new Dictionary<int, IList<string>>();

            MigrationVersion1();
        }

        public Dictionary<int, IList<string>> Migrations { get; set; }

        private void MigrationVersion1()
        {
            IList<string> steps = new List<string>();

            steps.Add("CREATE TABLE \"Usuario\" (\"Id\" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , \"Nombre\" TEXT, \"Correo\" TEXT, \"Contrasena\" TEXT, \"Puntuado\" TEXT)");
            steps.Add("CREATE TABLE \"Conductor\" (\"Id\" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , \"Nombre\" TEXT, \"Correo\" TEXT, \"Contrasena\" TEXT)");
            steps.Add("CREATE TABLE \"Viaje\" (\"IdConductor\" INTEGER , \"IdUsuario\" INTEGER , \"Destino\" TEXT, \"Ubicacion\" TEXT, \"Tarifa\" TEXT, \"Puntuado\" TEXT)");

            Migrations.Add(1, steps);
        }
    }
}