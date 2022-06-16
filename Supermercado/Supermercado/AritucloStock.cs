using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    public class ArticuloStock
    {
        private Articulo objArticulo = null;
        private int cantidad = 0;

        public ArticuloStock() { }

        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
    }
}
