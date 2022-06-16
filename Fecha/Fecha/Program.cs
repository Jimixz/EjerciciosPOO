using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fecha
{
    public class Fecha
    {
        int dd;
        int mm;
        int aa;

        public Fecha()
        { }

        public Fecha(int dd, int mm, int aa)
        {
            this.dd = dd;
            this.mm = mm;
            this.aa = aa;
        }

        public void AsignarDD(int dd)
        {
            this.dd = dd;

            return;
        }

        public void AsignarMM(int mm)
        {
            this.mm = mm;

            return;
        }

        public void AsignarAA(int aa)
        {
            this.aa = aa;

            return;
        }

        public int ObtenerDD()
        {
            return (this.dd);
        }

        public int ObtenerMM()
        {
            return (this.mm);
        }

        public int ObtenerAA()
        {
            return (this.aa);
        }

        public int CompararFecha(Fecha fecha)
        {
            if (this.aa < fecha.ObtenerAA())
            {
                return (-1);
            }

            if (this.aa > fecha.ObtenerAA())
            {
                return (1);
            }

            if (this.mm < fecha.ObtenerMM())
            {
                return (-1);
            }

            if (this.mm > fecha.ObtenerMM())
            {
                return (1);
            }

            if (this.dd < fecha.ObtenerDD())
            {
                return (-1);
            }

            if (this.dd > fecha.ObtenerDD())
            {
                return (1);
            }

            return (0);
        }

        public int ValidarFecha()
        {
            if (this.aa < 0 || this.aa != 2019)
            {
                return (-3);
            }

            if ((this.mm < 1) || (this.mm > 12))
            {
                return (-2);
            }

            if (this.dd < 1 || this.dd > 31)
            {
                return (-1);
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
                        return (-1);
                    }

                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    if (this.dd > 30)
                    {
                        return (-1);
                    }

                    break;
                case 2:
                    if ((this.aa % 4) != 0)
                    {
                        if (this.dd > 28)
                        {
                            return (-1);
                        }

                        break;
                    }

                    if ((this.aa % 100) == 0)
                    {
                        if ((this.aa % 400) != 0)
                        {
                            if (this.dd > 28)
                            {
                                return (-1);
                            }
                        }
                    }

                    if (this.dd > 29)
                    {
                        return (-1);
                    }

                    break;

                default:
                    break;
            }

            return (0);
        }

        public int DiasTrasncurridos(Fecha f2)
        {
            int difDias = 0, diaMes = 0;
            int diasRestantes = 0;

            if(this.CompararFecha(f2) != -1)
            {
                return -1;
            }

            if (this.mm == f2.mm && this.aa == f2.aa)
            {
                diasRestantes = f2.dd - this.dd;
                return diasRestantes;
            }

            for (int i = this.mm + 1; i < f2.mm; i++)
            {
                diaMes = diaMes + ObtenerDiasDelMes(i);
            }

            difDias = (ObtenerDiasDelMes(this.mm) - this.dd) + f2.dd;

            diasRestantes = diaMes + difDias;

            return diasRestantes;
        }

        public int ObtenerDiasDelMes(int numMes)
        {
            int diaMes = 0;

            switch (numMes)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    diaMes = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    diaMes = 30;
                    break;
                case 2:
                    //if ((this.aa % 4) != 0)
                    //{
                    //    diaMes = 28;
                    //    break;
                    //}

                    //if ((this.aa % 100) == 0)
                    //{
                    //    if ((this.aa % 400) != 0)
                    //    {
                    //        diaMes = 28;
                    //    }
                    //}
                    //diaMes = 29;
                    diaMes = 28;
                    break;

                default:
                    break;
            }


            return diaMes;
        }
        public void MostrarFecha()
        {
            Console.WriteLine("Fecha: {0}/{1}/{2}", dd, mm, aa);

            return;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int dd;
            int mm;
            int aa;
            Fecha objFecha1 = new Fecha();
            Fecha objFecha2 = new Fecha();

            // Ingrese los datos de la primera fecha.
            Console.WriteLine("Primera Fecha: ");
            Console.Write("Ingrese Año: ");
            aa = Convert.ToInt32(Console.ReadLine());
            objFecha1.AsignarAA(aa);

            while (objFecha1.ValidarFecha() == -3)
            {
                Console.WriteLine("Mal ingresado el año, vuelva a ingresarlo");
                aa = Convert.ToInt32(Console.ReadLine());
                objFecha1.AsignarAA(aa);
            }

            Console.Write("Ingrese Mes: ");
            mm = Convert.ToInt32(Console.ReadLine());
            objFecha1.AsignarMM(mm);

            while (objFecha1.ValidarFecha() == -2)
            {
                Console.WriteLine("Mal ingresado el mes, vuelva a ingresarlo");
                mm = Convert.ToInt32(Console.ReadLine());
                objFecha1.AsignarMM(mm);
            }

            Console.Write("Ingrese Dia: ");
            dd = Convert.ToInt32(Console.ReadLine());
            objFecha1.AsignarDD(dd);

            while (objFecha1.ValidarFecha() == -1)
            {
                Console.WriteLine("Mal ingresado el dia, vuelva a ingresarlo");
                dd = Convert.ToInt32(Console.ReadLine());
                objFecha1.AsignarDD(dd);
            }

            Console.Clear();

            // Ingrese los datos de la segunda fecha.
            Console.WriteLine("Segunda Fecha: ");
            Console.Write("Ingrese Año: ");
            aa = Convert.ToInt32(Console.ReadLine());
            objFecha2.AsignarAA(aa);

            while (objFecha2.ValidarFecha() == -3)
            {
                Console.WriteLine("Mal ingresado el año, vuelva a ingresarlo");
                aa = Convert.ToInt32(Console.ReadLine());
                objFecha2.AsignarAA(aa);
            }

            Console.Write("Ingrese Mes: ");
            mm = Convert.ToInt32(Console.ReadLine());
            objFecha2.AsignarMM(mm);

            while (objFecha2.ValidarFecha() == -2)
            {
                Console.WriteLine("Mal ingresado el mes, vuelva a ingresarlo");
                mm = Convert.ToInt32(Console.ReadLine());
                objFecha2.AsignarMM(mm);
            }

            Console.Write("Ingrese Dia: ");
            dd = Convert.ToInt32(Console.ReadLine());
            objFecha2.AsignarDD(dd);

            while (objFecha2.ValidarFecha() == -1)
            {
                Console.WriteLine("Mal ingresado el dia, vuelva a ingresarlo");
                dd = Convert.ToInt32(Console.ReadLine());
                objFecha2.AsignarDD(dd);
            }

            Console.Clear();

            Console.WriteLine("La primera fecha es: ");
            objFecha1.MostrarFecha();

            Console.WriteLine("La segunda fecha es: ");
            objFecha2.MostrarFecha();

            if (objFecha1.CompararFecha(objFecha2) < 0)
            {
                Console.WriteLine("La primera fecha es menor a la segunda");        
            }
            else
            {
                if (objFecha1.CompararFecha(objFecha2) > 0)
                {
                    Console.WriteLine("La primera fecha es mayor a la segunda");
                }
                else
                {
                    Console.WriteLine("La primera fecha es igual a la segunda");
                }

            }

            int diasTranscurridos = objFecha1.DiasTrasncurridos(objFecha2);
            Console.WriteLine("Los dias transcurridos : " + ((diasTranscurridos == -1)? "No se puede calcular": diasTranscurridos.ToString()));

            Console.ReadKey();
        }
    }
}
