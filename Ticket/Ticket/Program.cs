using System;
using System.Collections.Generic;

namespace Ticket
{
    class Program
    {
        //static List<TicketTurno> listaTurno = new List<TicketTurno>();
        //static int contadorTurno = 0;
        static void Main(string[] args)
        {
            MenuInicial();
            return;            
        }

        public static void MenuInicial()
        {
            TicketTurno objTicketTurno = new TicketTurno();
            TicketSala objTicketSala = new TicketSala();
            TicketColectivo objTicketColectivo = new TicketColectivo();

            Console.WriteLine("----------  ELEJIR TIPO DE TICKETS  ----------");
            Console.Write("\n 1 - 'Ticket Turno' ");
            Console.Write("\n 2 - 'Ticket Sala' ");
            Console.Write("\n 3 - 'Ticket Colectivo' NO DISPONIBLE ");
            Console.Write("\n 4 -  Cerrar Programa.");

            var _opc = Console.ReadKey();

            switch (_opc.KeyChar)
            {
                case '1':
                    Console.Clear();
                    objTicketTurno.Menu();
                    break;
                case '2':
                    Console.Clear();
                    objTicketSala.Menu();
                    break;
                case '3':
                    Console.Clear();
                    //objTicketColectivo.Menu();
                    MenuInicial();
                    break;
                case '4':
                    Console.Clear();
                    Console.Write("El programa se cerro, de forma exitosa...");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }

            return;
        }  

    }
}
