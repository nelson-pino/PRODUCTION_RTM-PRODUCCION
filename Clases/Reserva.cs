using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitramaAPP.Clases
{
    public class Reserva
    {
        public int Transac { get; set; }
        public string OrdenTrabajo { get; set; }
        public string OrdenServicio { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaPlan { get; set; }
        public string IdCust { get; set; }
        public string Customer_Name { get; set; }
        public string Commentary { get; set; }
        public int IndexProduct { get; set; }

        public  List<string> items;
        public Reserva()
        {
            items = new List<string>();
        }
    }
}
