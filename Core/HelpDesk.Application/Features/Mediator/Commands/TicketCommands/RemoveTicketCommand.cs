namespace HelpDesk.Application.Features.Mediator.Commands.TicketCommands
{
    public class RemoveTicketCommand : IRequest
    {
        public RemoveTicketCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
