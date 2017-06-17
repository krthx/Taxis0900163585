using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Taxis0900163585.Models;

namespace Taxis0900163585.Data
{
    internal class TaxisContext : DbContext
    {
        public DbSet<Conductor> Conductores { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Viaje> Viajes { get; set; }
    }
}