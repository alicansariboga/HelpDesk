namespace HelpDesk.Application.Features.Mediator.Handlers.TicketHandlers
{
    public class RemoveTicketCommandHandler : IRequestHandler<RemoveTicketCommand>
    {
        private readonly IRepository<TicketDocument> _repository;

        public RemoveTicketCommandHandler(IRepository<TicketDocument> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveTicketCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
