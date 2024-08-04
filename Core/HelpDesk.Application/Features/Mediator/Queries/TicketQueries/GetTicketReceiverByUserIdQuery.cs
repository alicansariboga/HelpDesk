namespace HelpDesk.Application.Features.Mediator.Queries.TicketQueries
{
    public class GetTicketReceiverByUserIdQuery : IRequest<List<GetTicketReceiverByUserIdQueryResult>>
    {
        public GetTicketReceiverByUserIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
