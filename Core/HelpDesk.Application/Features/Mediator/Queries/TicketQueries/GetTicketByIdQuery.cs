namespace HelpDesk.Application.Features.Mediator.Queries.TicketQueries
{
    public class GetTicketByIdQuery : IRequest<GetTicketByIdQueryResult>
    {
        public GetTicketByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
