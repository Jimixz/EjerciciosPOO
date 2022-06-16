using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Interface;

namespace Ticket
{
    class Hora: IHora, IGeneral
    {
        private int hh;
        private int mm;
        private int ss;

        public Hora()
        { }

        public Hora(int hh, int mm, int ss)
        {
            this.hh = hh;
            this.mm = mm;
            this.ss = ss;
        }

        public int Horas { get=> this.hh; set => this.hh = value; }
        public int Minutos { get => this.mm; set => this.mm = value; }
        public int Segundos { get => this.ss; set => this.ss = value; }

        public bool Validar()
        {
            if ((this.hh < 0) || (this.hh > 23))
            {
                return (false);
            }

            if ((this.mm < 0) || (this.mm > 59))
            {
                return (false);
            }

            if ((this.ss < 0) || (this.ss > 59))
            {
                return (false);
            }


            return (true);
        }

        public int Comparar(int hh, int mm, int ss)
        {
            if (this.hh < hh)
            {
                return (-1);
            }

            if (this.hh > hh)
            {
                return (1);
            }

            if (this.mm < mm)
            {
                return (-1);
            }

            if (this.mm > mm)
            {
                return (1);
            }

            if (this.ss < ss)
            {
                return (-1);
            }

            if (this.ss > ss)
            {
                return (1);
            }

            return (0);
        }
        public int Comparar(Hora hora)
        {
            return this.Comparar(hora.hh, hora.mm, hora.ss);
        }


        public void Mostrar()
        {
            Console.WriteLine("Hora: {0}:{1}:{2}", hh, mm, ss);

            return;
        }
    }
}
