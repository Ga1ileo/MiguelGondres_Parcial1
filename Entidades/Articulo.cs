using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiguelGondres_Parcial1.Entidades
{
    public class Articulo
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }

        public Articulo()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Existencia = string.Empty;
            Costo = 0;
            ValorInventario = 0;
        }
    }
}
