using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    public class Caja
    {

        private int numero = 0;
        private double monto = 0;
        public Caja() { }

        public List<Venta> listaVenta = new List<Venta>();
        public int Numero { get { return this.numero; } set { this.numero = value; } }
        public double Monto { get { return this.monto; } set { this.monto = value; } }
        public void CargarVentaDia(int numero)
        {
            switch (numero)
            {
                case 2221:
                    Venta objVenta = new Venta();
                    objVenta.CargarVentaDia(this.numero);
                    listaVenta.Add(objVenta);
                    break;
                case 2222:
                    Venta objVenta1 = new Venta();
                    objVenta1.CargarVentaDia(this.numero);
                    listaVenta.Add(objVenta1);
                    break;
                case 2223:
                    Venta objVenta2 = new Venta();
                    objVenta2.CargarVentaDia(this.numero);
                    listaVenta.Add(objVenta2);
                    break;
                case 2224:
                    Venta objVenta3 = new Venta();
                    objVenta3.CargarVentaDia(this.numero);
                    listaVenta.Add(objVenta3);
                    break;
                case 2225:
                    Venta objVenta4 = new Venta();
                    objVenta4.CargarVentaDia(this.numero);
                    listaVenta.Add(objVenta4);
                    break;
                case 2226:
                    Venta objVenta5 = new Venta();
                    objVenta5.CargarVentaDia(this.numero);
                    listaVenta.Add(objVenta5);
                    break;
                default:
                    break;
            }


        }

        public void MostrarListaVenta()
        {
            foreach(var item in listaVenta)
            {
                Console.WriteLine("TICKET : {0}", item.NroTicket);
                Console.WriteLine("TOTAL DE LA VENTA : {0}", item.Monto);
                Console.WriteLine("FECHA : {0}", item.Fecha);
                Console.WriteLine("ARTICULOS VENDIDOS");

                foreach (var item2 in item.listaArticuloVenta)
                {                 
                    Console.Write("\nNOMBRE : {0}", item2.Articulo.Nombre);
                    Console.Write(" | PRECIO : {0}$", item2.Articulo.Precio);
                    Console.Write(" | CODIGO : {0}", item2.Articulo.Codigo);
                    Console.Write(" | CANTIDAD : {0}",item2.Cantidad);
                }
                Console.WriteLine("\n\n=========================================");
            }
        }

        public double ObtenerMontoVentasTotal()
        {
            double monto = 0;
            foreach(var item in listaVenta)
            {
                foreach(var item2 in item.listaArticuloVenta)
                {
                    monto += item2.Monto;
                }
            }

            return monto;
        }

    }
}
