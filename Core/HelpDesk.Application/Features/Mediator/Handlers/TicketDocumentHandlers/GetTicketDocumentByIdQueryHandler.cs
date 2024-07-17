
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketDocumentHandlers
{
    public class GetTicketDocumentByIdQueryHandler : IRequestHandler<GetTicketDocumentByIdQuery, GetTicketDocumentByIdQueryResult>
    {
        private readonly IRepository<TicketDocument> _repository;

        public GetTicketDocumentByIdQueryHandler(IRepository<TicketDocument> repository)
        {
            _repository = repository;
        }

        public async Task<GetTicketDocumentByIdQueryResult> Handle(GetTicketDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTicketDocumentByIdQueryResult
            {
                Id = values.Id,
                File = values.File,
                CreatedDate = values.CreatedDate,
                TicketId = values.TicketId,
            };
        }
    }
}
