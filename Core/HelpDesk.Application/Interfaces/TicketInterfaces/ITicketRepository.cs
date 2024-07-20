using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Application.Interfaces.TicketInterfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetTicketByUserId(int id);
    }
}
