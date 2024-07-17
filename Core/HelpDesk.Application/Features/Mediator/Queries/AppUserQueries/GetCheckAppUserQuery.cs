using HelpDesk.Application.Features.Mediator.Results.AppUserResults;

namespace HelpDesk.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
