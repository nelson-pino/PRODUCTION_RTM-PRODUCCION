using System;
using System.Collections.Generic;

namespace RitramaAPP.Clases
{
    public class Orden_Items
    {
        public string renglon { get; set; }
        public string Product_id { get; set; }
        public string Product_name { get; set; }
        public Int32 Cantidad { get; set; }
        public string Unidad { get; set; }
        public decimal Width { get; set; }
        public decimal Large { get; set; }
        public decimal Msi { get; set; }
        List<Roll_Details> Rollos { get; set; }
        public string numero { get; set; }
    }
}
