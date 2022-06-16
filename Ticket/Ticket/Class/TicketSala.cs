using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Interface;

namespace Ticket
{
    class TicketSala: Ticket, IIVA
    {

        private const int FILA = 5;
        private const int COLUM = 5;
        private const double PRECIO_TICKET = 125.99;
        private const int DESCUENTO_POR_PERSONA = 5;
        private const int IVA = 10;
        private const int MAX_LIMITE_RESERVA = 5;
        private const int MIN_LIMITE_RESERVA = 1;

        private int nroTicket = 0;
        private double precio = 0;
        private int descuento = 0;
        private double factura = 0;
        private int fila = 0;
        private int silla = 0;
        private int iva = 0;
        private int reserva = 0;
        
        public TicketSala() { }
        public TicketSala(int d, int m, int a, int hh, int mm, int ss, int numero) : base(d, m, a, hh, mm, ss, numero) { }

        public double Precio { get=> this.precio; set=> this.precio = value; }
        public int Descuento { get => this.descuento; set => this.descuento = value; }
        public double Factura { get => this.factura; set => this.factura = value; }
        public int Iva { get => this.iva; set => this.iva = value; }
        public int Fila { get => this.fila; set => this.fila = value; }
        public int Silla { get => this.silla; set => this.silla = value; }
        public int Reserva { get => this.reserva; set => this.reserva = value; }
        public int NroTicket { get => this.nroTicket; set => this.nroTicket = value; }

        private int[,] sillaSala = new int[FILA, COLUM];

        public List<TicketSala> listaTicketSala = new List<TicketSala>();

        public override bool Validar()
        {
            if (this.objFecha.Validar() == true && this.objHora.Validar() == true)
            {
                return true;
            }

            return false;
        }

        public override void Mostrar()
        {
            foreach (var item in this.listaTicketSala)
            {
                Console.WriteLine("\n----------  TICKET CINE : {0}  ----------", item.numero);
                Console.WriteLine("NroTicket: {0}", item.numero);
                item.objFecha.Mostrar();
                item.objHora.Mostrar();
                Console.WriteLine("Nombre pelicula : El Bromas");
                Console.WriteLine("Numero de personas : {0}", item.reserva);
                Console.WriteLine("Descuento aplicado : {0}%", item.descuento);
                Console.WriteLine("IVA aplicado : {0}%", item.iva);
                Console.WriteLine("Precio final : {0}$", Math.Round(item.precio, 2));
            }

            Console.WriteLine("\nAprete una tecla para volver al menu...");
            Console.ReadKey();
            Console.Clear();
            this.Menu();
        }

        public override void Menu()
        {
            Console.WriteLine("----------  TICKET SALA ----------");

            Console.Write("\n 1 - Comprar 'Ticket' ");
            Console.Write("\n 2 - Mostrar 'Ticket Comprados' ");
            Console.Write("\n 3 - Volver al menu prinicpal ");
            Console.Write("\n 4 - Cerrar el programa ");

            var _opc = Console.ReadKey();

            switch (_opc.KeyChar)
            {
                case '1':
                    Console.Clear();
                    this.CrearTicket();
                    break;
                case '2':
                    Console.Clear();
                    this.Mostrar();
                    break;
                case '3':                    
                    Console.Clear();
                    Program.MenuInicial();
                    break;
                case '4':
                    Console.WriteLine("Aprete una tecla, para cerrar la aplicación.");
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("La opcion ingresada no es valida, aprete cualquier tecla.");
                    Console.ReadKey();
                    break;
            }
        }

        public void CrearTicket()
        {
            // Genero un numero de ticket aleatorio.
            int nroTicket = this.GenerarCodigoRandom();

            // Genero la fecha.
            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int año = DateTime.Now.Year;

            // Genero la hora.
            int hora = DateTime.Now.Hour;
            int minuto = DateTime.Now.Minute;
            int segundos = DateTime.Now.Second;

            TicketSala objTicketSala = new TicketSala(dia, mes, año, hora, minuto, segundos, nroTicket);

            bool Validar = objTicketSala.Validar();

            if (Validar == true)
            {
                this.ComprarTicket(objTicketSala);

                listaTicketSala.Add(objTicketSala);

                Console.Clear();
                Console.WriteLine("La compra se ha realizado con exito!!!... aprete una tecla.");
                Console.ReadKey();
                Console.Clear();
                this.Menu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El ticket no se pudo generar, aprete una tecla para volver a intentar.");
                Console.ReadKey();
                Console.Clear();
                this.CrearTicket();
            }      

        }
        public void ComprarTicket(TicketSala objTicketSala)
        {
            int reserva = 0;
            bool EsValido = false;

            this.MostrarAsientos();
           
            Console.Write("\n\nIngrese el numero de asientos a reservar: ");
            reserva = Int32.Parse(Console.ReadLine());

            EsValido = this.ValidarAsientos(reserva);

            if (EsValido == true)
            {
                double precio = 0;
                int descuento = 0;
                double precioDescuento = 0;
                double iva = 0;
                double precioFinal = 0;               

                precio = this.CalcularPrecio(reserva);
                descuento = this.ObtenerDescuento(reserva);
                precioDescuento = this.AplicarDescuento(precio, descuento);
                iva = Convert.ToDouble(this.AgregarIVA());                
                precioFinal = ((iva / 100) * precioDescuento) + precioDescuento;

                Console.WriteLine("\nPrecio Total : {0}$", Math.Round(precio, 2));
                Console.WriteLine("Descuento aplicado : {0}%", descuento);
                Console.WriteLine("Precio con descuento: {0}$", Math.Round(precioDescuento, 2));
                Console.WriteLine("IVA aplicado : {0}%", iva);
                Console.WriteLine("Cantidad de personas : {0}", reserva);


                Console.WriteLine("\nPrecio Final : {0}$", Math.Round(precioFinal, 2));

                Console.WriteLine("\nDesea realizar la compra ? 1-Si / 2-No");
                var _opc = Console.ReadKey();

                switch (_opc.KeyChar)
                {
                    case '1':
                        Console.Clear();                       
                        objTicketSala.Precio = precioFinal;
                        objTicketSala.Descuento = descuento;
                        objTicketSala.Iva = Convert.ToInt32(iva);
                        objTicketSala.Factura = 0;
                        objTicketSala.Reserva = reserva;
                        objTicketSala.NroTicket = objTicketSala.Numero;
                        this.ReservarAsientos(reserva);
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("La compra se cancelo con exito!... presione cualquier tecla.");
                        Console.ReadKey();
                        Console.Clear();
                        Program.MenuInicial();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("La opcion ingresada no es valida, aprete cualquier tecla.");
                        Console.ReadKey();
                        this.Menu();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("La cantidad de asiento que ingreso, supera a la cantidad de asientos libre...");
                Console.WriteLine("Volver a ingresar? 1-Si / 2-No");
                var _opc = Console.ReadKey();

                switch (_opc.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        this.ComprarTicket(objTicketSala);
                        break;
                    case '2':
                        Console.Clear();
                        this.Menu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("La opcion ingresada no es valida, aprete cualquier tecla.");
                        Console.ReadKey();
                        this.Menu();
                        break;
                }
            }
        }

        public bool ValidarAsientos(int reserva)
        {
            int contador = 0;

            for (int i = 0; i < this.sillaSala.GetLength(0); i++)
            {             
                for (int k = 0; k < this.sillaSala.GetLength(1); k++)
                {
                    if (this.sillaSala[i, k] == 0)
                    {
                        contador++;
                    }                   
                }
           
            }

            if (reserva > MAX_LIMITE_RESERVA || reserva < MIN_LIMITE_RESERVA)
            {
                return false;
            }

            if (reserva > contador)
            {
                return false;
            }

            return true;
        }

        public void MostrarAsientos()
        {
            string ocupado = "BUSY";
            string desocupado = "FREE";

            int contador = 0;
            int contadorFree = 0;

            for (int i = 0; i < this.sillaSala.GetLength(0); i++)
            {
                Console.Write("F{0}=> ", i + 1);

                for (int k = 0; k < this.sillaSala.GetLength(1); k++)
                {
                    contador++;
                    if (this.sillaSala[i, k] == 0) 
                    {
                        contadorFree++;
                        Console.Write("Silla {0} [{1}] | ", contador, desocupado);
                    }

                    if (this.sillaSala[i, k] == 1) 
                    {
                        Console.Write("Silla {0} [{1}] | ", contador, ocupado);
                    }
  
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nAsientos Libres: {0}", contadorFree);
        }

        public void ReservarAsientos(int reserva)
        {
            this.MostrarAsientos();

            int auxReserva = reserva;
            int fila = 0;
            int silla = 0;


            Console.WriteLine("\n\nPersona[{0}] ", auxReserva);

            Console.Write("Elejir Fila : ");
            fila = Int32.Parse(Console.ReadLine());

            Console.Write("Elejir N° Silla : ");
            silla = Int32.Parse(Console.ReadLine());

            auxReserva = this.AsignarSilla(fila, silla, reserva);

            if (auxReserva != 0)
            {
                Console.Clear();
                this.ReservarAsientos(auxReserva);
            }

            return;
        }

        public int AsignarSilla(int fila, int silla, int reserva)
        {
            fila = fila - 1;
            silla = silla - 1;

            for (int j = 0; j < this.sillaSala.GetLength(0); j++)
            {

                for (int k = 0; k < this.sillaSala.GetLength(1); k++)
                {
                    int valor = this.sillaSala[j, k];

                    if (valor == 0 && j == fila && k == silla)
                    {
                        reserva = reserva - 1;
                        this.sillaSala[j, k] = 1;

                        if(reserva == 0)
                        {
                            break;
                        }
                    }

                    if (valor == 1 && j == fila && k == silla)
                    {
                        Console.WriteLine("El asiento ya esta ocupado, elija otro...");
                        Console.ReadKey();
                        Console.Clear();
                        return reserva;
                    }

                }

                if (reserva == 0)
                {
                    break;
                }
            }

            return reserva;
        }
        public int AgregarIVA()
        {
            return IVA;
        }

        public double CalcularPrecio(int reserva)
        {
            return (PRECIO_TICKET * reserva);
        }

        public int ObtenerDescuento(int reserva)
        {
            return (DESCUENTO_POR_PERSONA * reserva);
        }

        public double AplicarDescuento(double precio, int descuento)
        {
            double des = Convert.ToDouble(descuento);
            double resultado = des / 100;
            return precio - (resultado * precio) ;
        }
        public int GenerarCodigoRandom()
        {
            // Genero un numero de ticket aleatorio.
            var seed = Environment.TickCount;
            var random = new Random(seed);
            int numeroTicket = random.Next(1000, 9999);

            return numeroTicket;
        }
    }
}
