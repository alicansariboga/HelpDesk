using HelpDesk.Domain.Entities.Common;

namespace HelpDesk.Domain.Entities
{
    public class TicketRoute : BaseEntity
    {
        public string TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string Description { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
