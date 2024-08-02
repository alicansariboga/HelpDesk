using HelpDesk.Domain.Entities.Common;

namespace HelpDesk.Domain.Entities
{
    public class Mail : BaseEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public bool IsRead { get; set; }
        List<TicketDocument> TicketDocuments { get; set; }
    }
}
