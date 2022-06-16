using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    public class ArticuloVenta
    {
        private int cantidad = 0;
        private double monto = 0;
        private Articulo objArticulo = null;

        public ArticuloVenta() { }

        public int Cantidad { get { return this.cantidad; } set { this.cantidad = value; } }
        public double Monto { get { return this.monto; } set { this.monto = value; } }
        public Articulo Articulo { get { return this.objArticulo; } set { this.objArticulo = value; } }

        public void CargarArticulo()
        {
            objArticulo = new Articulo();
            this.Articulo.CargarArticulo();
        }

        public void CargarVentas(int codigo, int cantidad)
        {            
            this.CargarArticulo();

            this.Cantidad = cantidad;
            this.Articulo = this.Articulo.ObtenerArticulo(codigo);
            this.CargarMonto();

        }

        public void CargarMonto()
        {
            this.Monto = this.Cantidad * this.Articulo.Precio;
        }

    }
}
