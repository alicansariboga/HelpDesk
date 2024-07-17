namespace HelpDesk.Application.Features.Mediator.Commands.TicketStatusCommands
{
    public class UpdateTicketStatusCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
