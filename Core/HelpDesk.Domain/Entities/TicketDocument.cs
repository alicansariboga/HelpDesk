using HelpDesk.Domain.Entities.Common;
using HelpDesk.Domain.Enums;


namespace HelpDesk.Domain.Entities
{
    public class TicketDocument : BaseEntity
    {
        public string File { get; set; }
        public byte[] FileData { get; set; }
        public FileType FileType { get; set; }
        public string CreatedDate { get; set; }
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int? MailId { get; set; }
        public Mail Mail { get; set; }
    }
}
