namespace HelpDesk.Application.Features.Mediator.Results.TicketRouteResults
{
    public class GetTicketRouteByIdQueryResult
    {
        public int Id { get; set; }
        public string TicketId { get; set; }
        public string Description { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
