namespace HelpDesk.Application.Features.Mediator.Queries.MailQueries
{
    public class GetMailAdminByUserIdQuery : IRequest<List<GetMailAdminByUserIdQueryResult>>
    {
        public GetMailAdminByUserIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
