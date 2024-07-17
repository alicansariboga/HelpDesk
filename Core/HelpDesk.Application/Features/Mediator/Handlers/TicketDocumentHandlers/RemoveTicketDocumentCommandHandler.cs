
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketDocumentHandlers
{
    public class RemoveTicketDocumentCommandHandler : IRequestHandler<RemoveTicketDocumentCommand>
    {
        private readonly IRepository<TicketDocument> _repository;

        public RemoveTicketDocumentCommandHandler(IRepository<TicketDocument> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTicketDocumentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
