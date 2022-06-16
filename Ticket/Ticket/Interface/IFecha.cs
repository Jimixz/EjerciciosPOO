using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.Interface
{
    interface IFecha
    {
        int Comparar(Fecha fecha);

        int Comparar(int dd, int mm, int aa);
    }
}
