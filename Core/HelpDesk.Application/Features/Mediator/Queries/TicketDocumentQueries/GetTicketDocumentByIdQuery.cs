namespace HelpDesk.Application.Features.Mediator.Queries.TicketDocumentQueries
{
    public class GetTicketDocumentByIdQuery : IRequest<GetTicketDocumentByIdQueryResult>
    {
        public GetTicketDocumentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
