using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitramaAPP.Clases
{
    public class Reserva
    {
        public string Transac { get; set; }
        public string OrdenTrabajo { get; set; }
        public string OrdenServicio { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaPlan { get; set; }
        public string IdCust { get; set; }
        public string Commentary { get; set; }

    }
}
