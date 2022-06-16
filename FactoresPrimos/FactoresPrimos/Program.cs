using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoresPrimos
{
    class Entero
    {
        private int numero = 0;

        public Entero() { }

        public Entero(int numero)
        {
            this.numero = numero;
        }

        public int Numero { get => this.numero;
                            set => this.numero = value; }

        public void factorPrimo()
        {
            int numero = this.numero;
            int cont = 0, auxNumero = 0;

            List<int> listPrimos = new List<int>();
            cont = 2;
            while ((cont <= Math.Sqrt(numero)) & (numero > 1))
            {
                double a = Math.Sqrt(numero);
                if (numero % cont == 0)
                {
                    listPrimos.Add(cont);
                    numero = numero / cont;
                }
                else
                {
                    cont += 1;
                }
            }
            if (numero > 1)
            {
                listPrimos.Add(numero);
            }

            cont = 0;
            int[] vecPrimos = listPrimos.ToArray();

            Console.Write("\n{0} = ", this.numero);

            for (int i = 0; i < vecPrimos.Length; i++)
            {            

                if(auxNumero != vecPrimos[i])
                {
                    
                    Console.Write("({0} potencia {1})", vecPrimos[i], contarNumero(vecPrimos[i], vecPrimos));
                }

                auxNumero = vecPrimos[i];
            }
        }

        public int contarNumero(int numero, int[] vecPrimos)
        {

            int valor = 0;

            for(int i = 0; i < vecPrimos.Length; i++)
            {
                if(numero == vecPrimos[i])
                {
                    valor += 1;
                }
            }

            return valor;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numero = 0;
            Entero objEntero = new Entero();
            
            Console.WriteLine("Ingresar el Numero");
            numero = Int32.Parse(Console.ReadLine());

            objEntero.Numero = numero;

            objEntero.factorPrimo();


            Console.ReadLine();
        }
    }
}
