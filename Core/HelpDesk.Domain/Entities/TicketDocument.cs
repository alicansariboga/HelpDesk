using HelpDesk.Domain.Entities.Common;

namespace HelpDesk.Domain.Entities
{
    public class TicketDocument : BaseEntity
    {
        public string File { get; set; }
        public string CreatedDate { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
