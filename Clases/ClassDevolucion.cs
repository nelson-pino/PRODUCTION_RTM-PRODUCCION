using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitramaAPP.Clases
{
    public class ClassDevolucion
    {
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Id_Cust { get; set; }
        public string Razon { get; set; }
        public bool DocAnulado { get; set; }
        public readonly List<Item_Devol> items;
        public ClassDevolucion()
        {
            items = new List<Item_Devol>();
        }
    }
}
