using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Interface;

namespace Ticket
{
    abstract class  Ticket: IGeneral
    {
        protected int numero = 0;
        protected Fecha objFecha = new Fecha();
        protected Hora objHora = new Hora();

        protected Ticket() { }

        protected Ticket(int d, int m, int a, int hh, int mm, int ss, int numero)
        {
            this.numero = numero;
            objFecha = new Fecha(d, m, a);
            objHora = new Hora(hh, mm, ss);
        }
        protected int Numero { get => this.numero; }

        public abstract void Menu();
        public virtual void Mostrar()
        {
            Console.WriteLine("Numero Ticket : {0}", this.numero);
        }

        public virtual bool Validar()
        {
            if(this.numero < 0)
            {
                return false;
            }

            if(this.objHora.Validar() == false)
            {
                return false;
            }

            if(this.objFecha.Validar() == false)
            {
                return false;
            }

            return true;
        }

    }
}
