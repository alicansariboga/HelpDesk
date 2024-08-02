using HelpDesk.Application.Interfaces.MailInterfaces;
using HelpDesk.Persistence.Context;

namespace HelpDesk.Persistence.Repositories.MailRepositories
{
    public class MailRepository : IMailRepository
    {
        private readonly HelpDeskContext _context;

        public MailRepository(HelpDeskContext context)
        {
            _context = context;
        }

        public List<Mail> GetMailByUserId(int id)
        {
            var user = _context.AppUsers.Where(x => x.Id == id).FirstOrDefault();
            var userMail = user.Email;
            var value = _context.Mails.Where(x => x.Receiver == userMail).ToList();
            return value;
        }
    }
}
