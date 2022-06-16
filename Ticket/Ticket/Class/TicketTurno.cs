using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Interface;

namespace Ticket
{    
    class TicketTurno: Ticket
    {
        private int contadorTurno;
        private int nroSector = 0;
        private int nroTicketTurnoDia = 0;
        private string descSector = string.Empty;
        public TicketTurno() { }
        public TicketTurno(int d, int m, int a, int hh, int mm, int ss, int numero):base( d,  m,  a,  hh,  mm,  ss,  numero) {  }

        public int NumeroSector { get => this.nroSector; set => this.nroSector = value; }
        public int NumeroTicketDia { get => this.nroTicketTurnoDia; set => this.nroTicketTurnoDia = value; }
        public string DescSector { get => this.descSector; set => this.descSector = value; }

        List<TicketTurno> listaTurno = new List<TicketTurno>();
        public override void Mostrar()
        {
            foreach(var item in this.listaTurno)
            {
                Console.WriteLine("\n----------  TICKET {0} : {1}  ----------", item.descSector.ToUpper(), item.numero);
                Console.WriteLine("NroSector : {0}", item.nroSector);
                item.objFecha.Mostrar();
                item.objHora.Mostrar();
                Console.WriteLine("NroTicket : {0}", item.nroTicketTurnoDia);
            }

            Console.WriteLine("\nAprete una tecla para volver al menu...");
            Console.ReadKey();
            Console.Clear();
            this.Menu();
        }
        public override bool Validar()
        {
            if (this.objFecha.Validar() == true && this.objHora.Validar() == true)
            {
                return true;
            }

            return false;
        }

        public override void Menu()
        {
            Console.WriteLine("----------  TICKET TURNO ----------");

            Console.Write("\n 1 - Hacer 'Ticket Turno' ");
            Console.Write("\n 2 - Mostrar 'Ticket Turno' ");
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
            Console.WriteLine("----------  ELEJIR SECTOR (DISPONIBLES)  ----------");
            Console.Write("\n 1 - 'Pedeatria' ");
            Console.Write("\n 2 - 'Clinico' ");
            Console.Write("\n 3 - 'Ginecólogia' ");
            Console.Write("\n 4 - 'Oftalmología' ");
            Console.Write("\n 5 - 'Traumatologia' ");

            var _opc = Console.ReadKey();

            switch (_opc.KeyChar)
            {
                case '1':
                    Console.Clear();
                    this.GuardarTicket("Pedeatria");
                    Console.Clear();
                    this.Menu();
                    break;
                case '2':
                    Console.Clear();
                    this.GuardarTicket("Clinico");
                    Console.Clear();
                    this.Menu();
                    break;
                case '3':
                    Console.Clear();
                    this.GuardarTicket("Ginecólogia");
                    Console.Clear();
                    this.Menu();
                    break;
                case '4':
                    Console.Clear();
                    this.GuardarTicket("Oftalmología");
                    Console.Clear();
                    this.Menu();
                    break;
                case '5':
                    Console.Clear();
                    this.GuardarTicket("Traumatologia");
                    Console.Clear();
                    this.Menu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("La opcion ingresada no es valida, aprete cualquier tecla.");
                    Console.ReadKey();
                    Console.Clear();
                    this.CrearTicket();
                    break;
            }

            return;
        }

        public void GuardarTicket(string sector)
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

            TicketTurno objTicketTurno = new TicketTurno(dia, mes, año, hora, minuto, segundos, nroTicket);

            bool Validar = objTicketTurno.Validar();

            if (Validar == true)
            {
                contadorTurno++;

                objTicketTurno.NumeroSector = objTicketTurno.AsignarNroSector(sector);
                objTicketTurno.DescSector = sector;
                objTicketTurno.NumeroTicketDia = contadorTurno;

                listaTurno.Add(objTicketTurno);
      
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El ticket no se pudo generar, aprete una tecla para volver a intentar.");
                Console.ReadKey();
                Console.Clear();
                CrearTicket();
            }
        }
        public int AsignarNroSector(string sector)
        {
            switch (sector)
            {
                case "Pedeatria":
                    return 1001;
                case "Clinico":
                    return 1002;
                case "Ginecólogia":
                    return 1003;
                case "Oftalmología":
                    return 1004;
                case "Traumatologia":
                    return 1005;
                default:
                    return 0;
            }
        }

        public int GenerarCodigoRandom()
        {
            // Genero un numero de ticket aleatorio.
            var seed = Environment.TickCount;
            var random = new Random(seed);
            int numeroTicket = random.Next(1000,9999);

            return numeroTicket;
        }
    }
}
