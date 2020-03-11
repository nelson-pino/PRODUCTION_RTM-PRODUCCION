using System;

namespace RitramaAPP
{
    public class ClassProduct
    {
        public string Product_id { get; set; }
        public string ProductName { get; set; }
        public string Descripcion { get; set; }
        public string Codebar { get; set; }
        public string Referencia { get; set; }
        public string Categoria { get; set; }
        public Boolean MasterRolls { get; set; }
        public Boolean Rollo_Cortado { get; set; }
        public Boolean Resmas { get; set; }
        public Boolean Graphics { get; set; }
        public Boolean Anulado { get; set; }
        public double Precio { get; set; }
        public string Code_RC { get; set; }
        public decimal Ratio { get; set; }
    }
}
