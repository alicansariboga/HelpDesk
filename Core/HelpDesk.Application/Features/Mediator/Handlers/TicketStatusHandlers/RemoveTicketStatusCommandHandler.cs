
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketStatusHandlers
{
    public class RemoveTicketStatusCommandHandler : IRequestHandler<RemoveTicketStatusCommand>
    {
        private readonly IRepository<TicketStatus> _repository;

        public RemoveTicketStatusCommandHandler(IRepository<TicketStatus> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTicketStatusCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
