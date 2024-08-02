using HelpDesk.Application.Enums;

namespace HelpDesk.Application.Features.Mediator.Handlers.MailHandlers
{
    public class CreateMailCommandHandler : IRequestHandler<CreateMailCommand>
    {
        private readonly IRepository<Mail> _repository;

        public CreateMailCommandHandler(IRepository<Mail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateMailCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Mail
            {
                Title = request.Title,
                Message = request.Message,
                Sender = request.Sender,
                Receiver = request.Receiver,
                CreatedTime = request.CreatedTime,
                ModifiedTime = request.ModifiedTime,
                IsRead = request.IsRead,
            });
        }
    }
}
