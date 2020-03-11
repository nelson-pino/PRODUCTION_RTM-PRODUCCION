using System;

namespace RitramaAPP
{
    public class ClassRecepcion
    {
        public int Numero { get; set; }
        public string Supply_Id { get; set; }
        public DateTime Fecha_reg { get; set; }
        public string Hora_reg { get; set; }
        public string SupplyName { get; set; }
        public string Orden { get; set; }
        public double Width { get; set; }
        public double Lenght { get; set; }
        public double Width_metros { get; set; }
        public double Lenght_metros { get; set; }
        public int Splice { get; set; }
        public decimal Core { get; set; }
        public string Roll_ID { get; set; }
        public string Ubicacion { get; set; }
        public string Part_Number { get; set; }
        public string Unidad { get; set; }
        public string ProductName { get; set; }
        public Boolean Anulado { get; set; }
        public DateTime Fecha_produccion { get; set; }
        public DateTime Fecha_recepcion { get; set; }
        public Boolean Master { get; set; }
        public Boolean Resma { get; set; }
        public Boolean Graphics { get; set; }
        public string Embarque { get; set; }
        public string Palet_number { get; set; }
        public decimal Palet_cant { get; set; }
        public int Palet_paginas { get; set; }
        public string Tipo { get; set; }
        public int Num_sincro { get; set; }
        public bool Registro_movil { get; set; }
        public Boolean Disponible { get; set; }
        public double cant_despacho { get; set; }
    }
}
