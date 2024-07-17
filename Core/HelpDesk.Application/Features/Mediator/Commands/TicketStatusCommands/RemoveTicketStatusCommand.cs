namespace HelpDesk.Application.Features.Mediator.Commands.TicketStatusCommands
{
    public class RemoveTicketStatusCommand : IRequest
    {
        public RemoveTicketStatusCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
