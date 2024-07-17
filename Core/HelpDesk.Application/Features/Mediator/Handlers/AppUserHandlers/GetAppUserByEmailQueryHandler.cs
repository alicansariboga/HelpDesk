namespace HelpDesk.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserByEmailQueryHandler : IRequestHandler<GetAppUserByEmailQuery, GetAppUserByEmailQueryResult>
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserByEmailQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAppUserByEmailQueryResult> Handle(GetAppUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAppUserByEmail(request.Mail);
            return new GetAppUserByEmailQueryResult
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
