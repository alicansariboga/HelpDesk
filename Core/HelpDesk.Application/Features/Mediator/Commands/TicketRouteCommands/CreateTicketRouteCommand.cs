namespace HelpDesk.Application.Features.Mediator.Commands.TicketRouteCommands
{
    public class CreateTicketRouteCommand : IRequest
    {
        public string TicketId { get; set; }
        public string Description { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
