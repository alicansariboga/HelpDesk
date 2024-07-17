namespace HelpDesk.Application.Features.Mediator.Commands.TicketRouteCommands
{
    public class RemoveTicketRouteCommand : IRequest
    {
        public RemoveTicketRouteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
