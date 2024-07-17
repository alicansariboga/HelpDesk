namespace HelpDesk.Application.Features.Mediator.Handlers.TicketDocumentHandlers
{
    public class CreateTicketDocumentCommandHandler : IRequestHandler<CreateTicketDocumentCommand>
    {
        private readonly IRepository<TicketDocument> _repository;

        public CreateTicketDocumentCommandHandler(IRepository<TicketDocument> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateTicketDocumentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TicketDocument {
                File = request.File,
                CreatedDate = request.CreatedDate,
                TicketId = request.TicketId,
            });
        }
    }
}
