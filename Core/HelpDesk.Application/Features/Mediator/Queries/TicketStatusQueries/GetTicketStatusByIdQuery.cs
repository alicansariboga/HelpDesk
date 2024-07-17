namespace HelpDesk.Application.Features.Mediator.Queries.TicketStatusQueries
{
    public class GetTicketStatusByIdQuery : IRequest<GetTicketStatusByIdQueryResult>
    {
        public GetTicketStatusByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
