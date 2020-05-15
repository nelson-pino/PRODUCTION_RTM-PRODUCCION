using System;
using System.Collections.Generic;

namespace RitramaAPP.Clases
{
    public class ClassDespacho
    {
        public string Numero { get; set; }
        public DateTime Fecha_despacho { get; set; }
        public string Curstomer_id { get; set; }
        public string Curstomer_name { get; set; }
        public string Curstomer_direc { get; set; }
        public string Persona_entrega { get; set; }
        public string Vendedor_id { get; set; }
        public string Vendedor_name { get; set; }
        public string Transport_id { get; set; }
        public string Transport_name { get; set; }
        public string Chofer_id { get; set; }
        public string Chofer_name { get; set; }
        public string Placas_id { get; set; }
        public string Modelo_camion { get; set; }
        public string Tipo_embalaje { get; set; }
        public string Orden_trabajo { get; set; }
        public string Orden_compra { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Monto_itbis { get; set; }
        public decimal Total { get; set; }
        public List<Items_despacho> items;










    }
}
