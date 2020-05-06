using System;

namespace RitramaAPP.Clases
{
    public class AutorizeDocOc
    {
        public string Oc { get; set; }
        public DateTime Fecha { get; set; }
        public string ToAutorize { get; set; }
        public string Notes { get; set; }
        public bool CloseDocument { get; set; }
    }
}
