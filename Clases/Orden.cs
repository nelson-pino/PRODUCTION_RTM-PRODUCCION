using RitramaAPP.Clases;
using System;
using System.Collections.Generic;
namespace RitramaAPP
{
    public class Orden
    {
        public Orden()
        {

        }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fecha_produccion { get; set; }
        //rollid 1
        public string Rollid_1 { get; set; }
        public decimal Width_1 { get; set; }
        public decimal Lenght_1 { get; set; }
        public double Descartable1_pies { get; set; }
        public double Master_lenght1_Real { get; set; }
        public double Util1_Real_Width { get; set; }
        public double Util1_real_Lenght { get; set; }
        public double Rest1_width { get; set; }
        public double Rest1_lenght { get; set; }
        // rollid 2
        public string Rollid_2 { get; set; }
        public decimal Width_2 { get; set; }
        public decimal Lenght_2 { get; set; }
        public double Descartable2_pies { get; set; }
        public double Master_lenght2_Real { get; set; }
        public double Util2_Real_Width { get; set; }
        public double Util2_real_Lenght { get; set; }
        public double Rest2_width { get; set; }
        public double Rest2_lenght { get; set; }
        //datos del producto
        public string Product_id { get; set; }
        public string Product_name { get; set; }
        public Boolean Anulada { get; set; }
        public Boolean Procesado { get; set; }
        public int Status { get; set; }
        //datos de los cortes
        public double Inch_Ancho { get; set; }
        public double Longitud_Cortar { get; set; }
        public int Cortes_Ancho { get; set; }
        public int Cortes_Largo { get; set; }
        public int Cortes_Largo2 { get; set; }
        public int Cantidad_Rollos { get; set; }
        public int Cantidad_Rollos2 { get; set; }
        public List<Roll_Details> rollos;
        public List<Corte> Cortes;
    }
    public class Corte
    {
        public int Num { get; set; }
        public double Width { get; set; }
        public double Lenght { get; set; }
        public double Msi { get; set; }
        public string Orden { get; set; }
    }
}
