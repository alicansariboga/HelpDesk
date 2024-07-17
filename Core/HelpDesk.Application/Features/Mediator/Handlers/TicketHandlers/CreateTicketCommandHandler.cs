
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketHandlers
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
    {
        private readonly IRepository<Ticket> _repository;

        public CreateTicketCommandHandler(IRepository<Ticket> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ticket
            {
                Title = request.Title,
                Message = request.Message,
                Sender = request.Sender,
                Receiver = request.Receiver,
                CreatedTime = request.CreatedTime,
                ModifiedTime = request.ModifiedTime,
                Status = request.Status,
            });
        }
    }
}
