using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado
{
    public class Articulo
    {
        private int codigo { get; set; }
        private double precio { get; set; }
        private string nombre { get; set; }

        public Articulo() { }

        public int Codigo { get; set; }
        public double Precio { get; set; }
        public string Nombre { get; set; }

        public List<Articulo> listaArticulo = new List<Articulo>();

        public void CargarArticulo()
        {            
            Articulo objArticulo_1 = new Articulo();
            objArticulo_1.Nombre = "Coca-Cola";
            objArticulo_1.Precio = 99.99;
            objArticulo_1.Codigo = 111;
            listaArticulo.Add(objArticulo_1);

            Articulo objArticulo_2 = new Articulo();
            objArticulo_2.Nombre = "Snacks";
            objArticulo_2.Precio = 15.99;
            objArticulo_2.Codigo = 112;
            listaArticulo.Add(objArticulo_2);

            Articulo objArticulo_3 = new Articulo();
            objArticulo_3.Nombre = "Pepsi";
            objArticulo_3.Precio = 100.99;
            objArticulo_3.Codigo = 113;
            listaArticulo.Add(objArticulo_3);

            Articulo objArticulo_4 = new Articulo();
            objArticulo_4.Nombre = "Auriculares";
            objArticulo_4.Precio = 3065.99;
            objArticulo_4.Codigo = 114;
            listaArticulo.Add(objArticulo_4);

            Articulo objArticulo_5 = new Articulo();
            objArticulo_5.Nombre = "TV";
            objArticulo_5.Precio = 10029.99;
            objArticulo_5.Codigo = 115;
            listaArticulo.Add(objArticulo_5);

            Articulo objArticulo_6 = new Articulo();
            objArticulo_6.Nombre = "Monitor 144hz";
            objArticulo_6.Precio = 32000.20;
            objArticulo_6.Codigo = 116;
            listaArticulo.Add(objArticulo_6);

            Articulo objArticulo_7 = new Articulo();
            objArticulo_7.Nombre = "Mouse";
            objArticulo_7.Precio = 5394.99;
            objArticulo_7.Codigo = 117;
            listaArticulo.Add(objArticulo_7);

            Articulo objArticulo_8 = new Articulo();
            objArticulo_8.Nombre = "Celular";
            objArticulo_8.Precio = 16999.99;
            objArticulo_8.Codigo = 118;
            listaArticulo.Add(objArticulo_8);

            Articulo objArticulo_9 = new Articulo();
            objArticulo_9.Nombre = "Teclado";
            objArticulo_9.Precio = 3205.99;
            objArticulo_9.Codigo = 119;
            listaArticulo.Add(objArticulo_9);
        }

        public Articulo ObtenerArticulo(int codigo)
        {

            foreach (var item in listaArticulo)
            {
                if (item.Codigo == codigo)
                {
                    return item;
                }
            }

            return null;
        }

    }
}
