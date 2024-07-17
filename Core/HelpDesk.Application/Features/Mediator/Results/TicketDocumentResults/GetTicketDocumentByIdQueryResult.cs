namespace HelpDesk.Application.Features.Mediator.Results.TicketDocumentResults
{
    public class GetTicketDocumentByIdQueryResult
    {
        public int Id { get; set; }
        public string File { get; set; }
        public string CreatedDate { get; set; }
        public int TicketId { get; set; }
    }
}
