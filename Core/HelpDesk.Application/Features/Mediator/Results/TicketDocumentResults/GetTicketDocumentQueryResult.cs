namespace HelpDesk.Application.Features.Mediator.Results.TicketDocumentResults
{
    public class GetTicketDocumentQueryResult
    {
        public int Id { get; set; }
        public string File { get; set; }
        public string CreatedDate { get; set; }
        public int? TicketId { get; set; }
        public int? MailId { get; set; }
    }
}
