using HelpDesk.Application.Features.Mediator.Commands.AppUserCommands;

namespace HelpDesk.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class UpdateAppUserCommandHandler : IRequest<UpdateAppUserCommandHandler>
    {
        private readonly IRepository<AppUser> _repository;

        public UpdateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.ImageUrl = request.ImageUrl;
            values.UserName = request.UserName;
            values.NormalizedUserName = request.UserName.ToUpper();
            values.Email = request.Email;
            values.NormalizedEmail = request.Email.ToUpper();
            values.EmailConfirmed = request.EmailConfirmed;
            values.Password = request.Password;
            values.PhoneNumber = request.PhoneNumber;
            values.PhoneConfirmed = request.PhoneConfirmed;
            values.TwoFactorEnabled = request.TwoFactorEnabled;
            values.FailedLoginCount = request.FailedLoginCount;
            await _repository.UpdateAsync(values);
        }
    }
}
