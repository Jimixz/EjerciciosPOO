using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    public class Supermercado
    {
        private string nombre = string.Empty;
        private string direccion = string.Empty;
        private Caja[] objCaja = null;
        private Articulo objArticulo = null;

        public Supermercado() { }

        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Direccion { get { return this.direccion; } set { this.direccion = value; } }
        public Caja Caja { get { return this.objCaja[6]; } set { this.objCaja[6] = value; } }
       
        List<ArticuloStock> listaItemStock = new List<ArticuloStock>();

        public void CargarSuperMercado()
        {
            Console.WriteLine("Supermercado: {0}, {1}", this.Nombre = "SuperKrause", this.Direccion = "Av. Paseo Colon 650");            
            this.MostrarArticulo();
            this.MostrarVentaCaja();
        }
        public void CargarCaja()
        {
            objCaja = new Caja[6];
            for (int i = 0; i < objCaja.Length; i++)
            {
                objCaja[i] = new Caja();
                objCaja[i].Numero = 2221 + i;
                objCaja[i].CargarVentaDia(objCaja[i].Numero);
            }                   
        }
        public void MostrarVentaCaja()
        {
            this.CargarCaja();

            for(int i = 0; i < objCaja.Length; i++)
            {
                Console.WriteLine("\n\nCAJA [N°{0}]", objCaja[i].Numero);
                objCaja[i].MostrarListaVenta();
            }
            
        }

        public void MostrarArticulo()
        {
            objArticulo = new Articulo();

            objArticulo.CargarArticulo();
            Console.WriteLine("\nLISTA DE ARTICULOS ");
            Console.WriteLine("=========================================");
            foreach (var item in objArticulo.listaArticulo)
            {

                Console.Write("\nNOMBRE : {0}", item.Nombre);
                Console.Write(" | PRECIO : {0}$", item.Precio);
                Console.Write(" | CODIGO : {0}", item.Codigo);
            }
            Console.WriteLine("\n\n=========================================");
        }
    }
}
