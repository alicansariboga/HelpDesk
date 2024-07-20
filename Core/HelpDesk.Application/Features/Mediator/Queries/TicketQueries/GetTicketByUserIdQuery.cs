namespace HelpDesk.Application.Features.Mediator.Queries.TicketQueries
{
    public class GetTicketByUserIdQuery : IRequest<List<GetTicketByUserIdQueryResult>>
    {
        public GetTicketByUserIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
