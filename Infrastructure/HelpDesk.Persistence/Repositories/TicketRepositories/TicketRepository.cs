using HelpDesk.Application.Interfaces.TicketInterfaces;
using HelpDesk.Persistence.Context;

namespace HelpDesk.Persistence.Repositories.TicketRepositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly HelpDeskContext _context;

        public TicketRepository(HelpDeskContext context)
        {
            _context = context;
        }

        public List<Ticket> GetTicketByUserId(int id)
        {
            var user = _context.AppUsers.Where(x => x.Id == id).FirstOrDefault();
            var userMail = user.Email;
            var value = _context.Tickets.Where(x => x.Sender == userMail).ToList();
            return value;
        }
    }
}
