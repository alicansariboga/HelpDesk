using HelpDesk.Application.Features.Mediator.Results.AppUserResults;

namespace HelpDesk.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetAppUserByIdQuery : IRequest<GetAppUserByIdQueryResult>
    {
        public GetAppUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
