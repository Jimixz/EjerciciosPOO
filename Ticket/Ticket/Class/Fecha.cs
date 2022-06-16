using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Interface;

namespace Ticket
{
    public class Fecha: IFecha, IGeneral
    {
        private int dd;
        private int mm;
        private int aa;

        public Fecha()
        { }

        public Fecha(int dd, int mm, int aa)
        {
            this.dd = dd;
            this.mm = mm;
            this.aa = aa;
        }

        public int Dia { get=> this.dd; set=> this.dd = value; }
        public int Mes { get => this.mm; set => this.mm = value; }
        public int Año { get => this.aa; set => this.aa = value; }
        public int Comparar(int dd, int mm, int aa)
        {
            if (this.aa < aa)
            {
                return (-1);
            }

            if (this.aa > aa)
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

            if (this.dd < dd)
            {
                return (-1);
            }

            if (this.dd > dd)
            {
                return (1);
            }

            return (0);
        }
        public int Comparar(Fecha fecha)
        {
            return this.Comparar(fecha.dd, fecha.mm, fecha.aa);
        }

        public bool Validar()
        {
            if ((this.aa < 0 || this.aa != 2019) || (this.mm < 1 || this.mm > 12) || (this.dd < 1 || this.dd > 31))
            {
                return (false);
            }

            switch (this.mm)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (this.dd > 31)
                    {
                        return (false);
                    }

                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    if (this.dd > 30)
                    {
                        return (false);
                    }

                    break;
                case 2:
                    if ((this.aa % 4) != 0)
                    {
                        if (this.dd > 28)
                        {
                            return (false);
                        }

                        break;
                    }

                    if ((this.aa % 100) == 0)
                    {
                        if ((this.aa % 400) != 0)
                        {
                            if (this.dd > 28)
                            {
                                return (false);
                            }
                        }
                    }

                    if (this.dd > 29)
                    {
                        return (false);
                    }

                    break;

                default:
                    break;
            }

            return (true);
        }

        public void Mostrar()
        {
            Console.WriteLine("Fecha: {0}/{1}/{2}", dd, mm, aa);

            return;
        }
    }
}
