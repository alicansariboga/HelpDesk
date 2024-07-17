namespace HelpDesk.Application.Features.Mediator.Commands.TicketStatusCommands
{
    public class CreateTicketStatusCommand : IRequest
    {
        public string Name { get; set; }
    }
}
