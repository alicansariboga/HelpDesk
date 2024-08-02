namespace HelpDesk.Application.Features.Mediator.Queries.MailQueries
{
    public class GetMailByIdQuery : IRequest<GetMailByIdQueryResult>
    {
        public GetMailByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
