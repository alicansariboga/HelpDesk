namespace HelpDesk.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                Name = request.Name,
                Surname = request.Surname,
                ImageUrl = "default",
                UserName = request.UserName,
                NormalizedUserName = request.UserName.ToUpper(),
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                EmailConfirmed = false,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                PhoneConfirmed = false,
                TwoFactorEnabled = false,
                FailedLoginCount = 0,
            });
        }
    }
}
