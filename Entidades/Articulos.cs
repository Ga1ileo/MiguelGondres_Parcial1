using System;
using System.Collections.Generic;
using System.Text;

namespace MiguelGondres_Parcial1.Entidades
{
    public class Articulos
    {
        public int ProductoId;
        public string Descripcion;
        public string Existencia;
        public decimal Costo;
        public decimal ValorInventario;

        public Articulos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Existencia = string.Empty;
            Costo = 0;
            ValorInventario = 0;
        }
    }
}
