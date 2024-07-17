using HelpDesk.Application.Features.Mediator.Queries.AppUserQueries;
using HelpDesk.Application.Features.Mediator.Results.AppUserResults;

namespace HelpDesk.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserByIdQueryHandler : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdQueryResult>
    {
        private readonly IRepository<AppUser> _repository;

        public GetAppUserByIdQueryHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetAppUserByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Surname = values.Surname,
                ImageUrl = values.ImageUrl,
                UserName = values.UserName,
                NormalizedUserName = values.NormalizedUserName,
                Email = values.Email,
                NormalizedEmail = values.NormalizedEmail,
                EmailConfirmed = values.EmailConfirmed,
                Password = values.Password,
                PhoneNumber = values.PhoneNumber,
                PhoneConfirmed = values.PhoneConfirmed,
                TwoFactorEnabled = values.TwoFactorEnabled,
                FailedLoginCount = values.FailedLoginCount,
            };
        }
    }
}
