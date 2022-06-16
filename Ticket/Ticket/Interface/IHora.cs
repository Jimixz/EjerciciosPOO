using System;
using System.Collections.Generic;
using System.Text;

namespace Ticket.Interface
{
    interface IHora
    {
        int Comparar(Hora hora);
        int Comparar(int hh, int mm, int ss);

    }

}
