
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketDocumentHandlers
{
    public class UpdateTicketDocumentCommandHandler : IRequestHandler<UpdateTicketDocumentCommand>
    {
        private readonly IRepository<TicketDocument> _repository;

        public UpdateTicketDocumentCommandHandler(IRepository<TicketDocument> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTicketDocumentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.File = request.File;
            values.TicketId = request.TicketId;
            values.CreatedDate = request.CreatedDate;
            await _repository.UpdateAsync(values);
        }
    }
}
