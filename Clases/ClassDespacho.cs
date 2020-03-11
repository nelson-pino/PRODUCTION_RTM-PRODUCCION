using System;
using System.Collections.Generic;

namespace RitramaAPP.Clases
{
    public class ClassDespacho
    {
        public string numero { get; set; }
        public DateTime fecha_despacho { get; set; }
        public string curstomer_id { get; set; }
        public string curstomer_name { get; set; }
        public string curstomer_direc { get; set; }
        public string persona_entrega { get; set; }
        public string vendedor_id { get; set; }
        public string vendedor_name { get; set; }
        public string transport_id { get; set; }
        public string transport_name { get; set; }
        public string chofer_id { get; set; }
        public string chofer_name { get; set; }
        public string placas_id { get; set; }
        public string modelo_camion { get; set; }
        public string tipo_embalaje { get; set; }
        public string orden_trabajo { get; set; }
        public string orden_compra { get; set; }
        public decimal subtotal { get; set; }
        public decimal monto_itbis { get; set; }
        public decimal total { get; set; }
        public List<Items_despacho> items;










    }
}
