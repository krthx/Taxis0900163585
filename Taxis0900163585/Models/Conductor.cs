using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxis0900163585.Models
{
    public class Conductor : Usuario
    {
        public string ModeloVehiculo { get; set; }

        public string Caracteristicas { get; set; }

        public Int32 Puntuado { get; set; }
    }
}