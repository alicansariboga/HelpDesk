using HelpDesk.Application.Features.Mediator.Queries.AppUserQueries;
using HelpDesk.Application.Features.Mediator.Results.AppUserResults;

namespace HelpDesk.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, List<GetAppUserQueryResult>>
    {
        private readonly IRepository<AppUser> _repository;

        public GetAppUserQueryHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAppUserQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                ImageUrl = x.ImageUrl,
                UserName = x.UserName,
                NormalizedUserName = x.NormalizedUserName,
                Email = x.Email,
                NormalizedEmail = x.NormalizedEmail,
                EmailConfirmed = x.EmailConfirmed,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                PhoneConfirmed = x.PhoneConfirmed,
                TwoFactorEnabled = x.TwoFactorEnabled,
                FailedLoginCount = x.FailedLoginCount,
            }).ToList();
        }
    }
}
