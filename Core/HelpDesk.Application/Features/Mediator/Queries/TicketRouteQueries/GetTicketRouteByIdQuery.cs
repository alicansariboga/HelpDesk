namespace HelpDesk.Application.Features.Mediator.Queries.TicketRouteQueries
{
    public class GetTicketRouteByIdQuery : IRequest<GetTicketRouteByIdQueryResult>
    {
        public GetTicketRouteByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
