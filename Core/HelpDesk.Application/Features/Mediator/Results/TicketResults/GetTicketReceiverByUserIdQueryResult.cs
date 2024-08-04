namespace HelpDesk.Application.Features.Mediator.Results.TicketResults
{
    public class GetTicketReceiverByUserIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int Status { get; set; }
        public int Value { get; set; }
    }
}
