using System;
using System.Collections.Generic;

namespace RitramaAPP
{
    public class ClassPedidos
    {
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string CustomerID { get; set; }
        public string CustomeerName { get; set; }
        public List<ClassItemsPedidos> Items { get; set; }

    }
}
