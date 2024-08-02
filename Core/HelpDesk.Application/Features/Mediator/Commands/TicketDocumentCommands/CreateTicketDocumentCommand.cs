namespace HelpDesk.Application.Features.Mediator.Commands.TicketDocumentCommands
{
    public class CreateTicketDocumentCommand : IRequest
    {
        public string File { get; set; }
        public string CreatedDate { get; set; }
        public int? TicketId { get; set; }
        public int? MailId { get; set; }
    }
}
