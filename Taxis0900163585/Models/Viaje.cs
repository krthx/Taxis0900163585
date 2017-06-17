using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxis0900163585.Models
{
    public enum Puntuacion { Malo, Regular, Bueno, Excelente };

    public class Viaje
    {
        public Int32 IdConductor { get; set; }

        public Int32 IdUsuario { get; set; }

        public string Ubicacion { get; set; }

        public string Destino { get; set; }

        public string Hora { get; set; }

        public double Tarifa { get; set; }

        public Puntuacion PuntuajeViaje { get; set; }
    }
}