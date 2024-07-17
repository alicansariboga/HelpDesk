namespace HelpDesk.Application.Features.Mediator.Commands.TicketDocumentCommands
{
    public class UpdateTicketDocumentCommand : IRequest
    {
        public int Id { get; set; }
        public string File { get; set; }
        public string CreatedDate { get; set; }
        public int TicketId { get; set; }
    }
}
