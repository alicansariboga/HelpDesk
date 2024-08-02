namespace HelpDesk.Application.Features.Mediator.Queries.MailQueries
{
    public class GetMailByUserIdQuery : IRequest<List<GetMailByUserIdQueryResult>>
    {
        public GetMailByUserIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
