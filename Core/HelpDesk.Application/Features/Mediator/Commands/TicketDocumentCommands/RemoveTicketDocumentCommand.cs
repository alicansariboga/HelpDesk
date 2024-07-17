namespace HelpDesk.Application.Features.Mediator.Commands.TicketDocumentCommands
{
    public class RemoveTicketDocumentCommand : IRequest
    {
        public RemoveTicketDocumentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
