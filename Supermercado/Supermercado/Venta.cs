using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    public class Venta
    {
        private int nroTicket = 0;
        private double monto = 0;
        private DateTime fecha = DateTime.Now;

        public Venta() { }
        public double Monto { get { return this.monto; } set { this.monto = value; } }
        public DateTime Fecha { get { return this.fecha; } set { this.fecha = value; } }
        public int NroTicket { get { return this.nroTicket; } set { this.nroTicket = value; } }

        public List<ArticuloVenta> listaArticuloVenta = new List<ArticuloVenta>();

        public void CargarVentaDia(int numero)
        {
            this.CargarListaVenta(numero);
            this.NroTicket = GenerarCodigoRandom();
            this.Monto = this.ObtenerMontoVentasTotal();
        }

        public void CargarListaVenta(int numero)
        {
            switch(numero)
            {
                case 2221:
                    ArticuloVenta objArticuloVenta = new ArticuloVenta();
                    objArticuloVenta.CargarVentas(111, 2);
                    listaArticuloVenta.Add(objArticuloVenta);

                    ArticuloVenta objArticuloVenta1 = new ArticuloVenta();
                    objArticuloVenta1.CargarVentas(112, 1);
                    listaArticuloVenta.Add(objArticuloVenta1);

                    ArticuloVenta objArticuloVenta2 = new ArticuloVenta();
                    objArticuloVenta2.CargarVentas(113, 4);
                    listaArticuloVenta.Add(objArticuloVenta2);

                    ArticuloVenta objArticuloVenta3 = new ArticuloVenta();
                    objArticuloVenta3.CargarVentas(114, 1);
                    listaArticuloVenta.Add(objArticuloVenta3);

                    ArticuloVenta objArticuloVenta4 = new ArticuloVenta();
                    objArticuloVenta4.CargarVentas(115, 3);
                    listaArticuloVenta.Add(objArticuloVenta4);
                    break;

                case 2222:
                    ArticuloVenta objArticuloVenta5 = new ArticuloVenta();
                    objArticuloVenta5.CargarVentas(118, 2);
                    listaArticuloVenta.Add(objArticuloVenta5);

                    ArticuloVenta objArticuloVenta6 = new ArticuloVenta();
                    objArticuloVenta6.CargarVentas(119, 1);
                    listaArticuloVenta.Add(objArticuloVenta6);
                    break;
                case 2223:
                    ArticuloVenta objArticuloVenta7 = new ArticuloVenta();
                    objArticuloVenta7.CargarVentas(119, 1);
                    listaArticuloVenta.Add(objArticuloVenta7);

                    ArticuloVenta objArticuloVenta8 = new ArticuloVenta();
                    objArticuloVenta8.CargarVentas(112, 2);
                    listaArticuloVenta.Add(objArticuloVenta8);

                    ArticuloVenta objArticuloVenta9 = new ArticuloVenta();
                    objArticuloVenta9.CargarVentas(111, 3);
                    listaArticuloVenta.Add(objArticuloVenta9);
                    break;
                case 2224:
                    ArticuloVenta objArticuloVenta10 = new ArticuloVenta();
                    objArticuloVenta10.CargarVentas(111, 3);
                    listaArticuloVenta.Add(objArticuloVenta10);
                    break;
                case 2225:
                    ArticuloVenta objArticuloVenta11 = new ArticuloVenta();
                    objArticuloVenta11.CargarVentas(119, 4);
                    listaArticuloVenta.Add(objArticuloVenta11);
                    break;
                case 2226:
                    ArticuloVenta objArticuloVenta12 = new ArticuloVenta();
                    objArticuloVenta12.CargarVentas(116, 4);
                    listaArticuloVenta.Add(objArticuloVenta12);

                    ArticuloVenta objArticuloVenta13 = new ArticuloVenta();
                    objArticuloVenta13.CargarVentas(117, 2);
                    listaArticuloVenta.Add(objArticuloVenta13);

                    ArticuloVenta objArticuloVenta14 = new ArticuloVenta();
                    objArticuloVenta14.CargarVentas(118, 1);
                    listaArticuloVenta.Add(objArticuloVenta14);

                    ArticuloVenta objArticuloVenta15 = new ArticuloVenta();
                    objArticuloVenta15.CargarVentas(119, 2);
                    listaArticuloVenta.Add(objArticuloVenta15);
                    break;
                default:
                    break;
            }


        }
        public int GenerarCodigoRandom()
        {
            // Genero un numero de ticket aleatorio.
            var seed = Environment.TickCount;
            var random = new Random(seed);
            int numeroTicket = random.Next(500, 9999);

            return numeroTicket;
        }
        public double ObtenerMontoVentasTotal()
        {
            double monto = 0;
            foreach(var item in listaArticuloVenta)
            {
                monto += item.Articulo.Precio;
            }
            return monto;
        }

    }
}
