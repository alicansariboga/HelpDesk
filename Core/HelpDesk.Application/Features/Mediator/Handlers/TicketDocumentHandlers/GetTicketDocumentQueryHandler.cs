
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketDocumentHandlers
{
    public class GetTicketDocumentQueryHandler : IRequestHandler<GetTicketDocumentQuery, List<GetTicketDocumentQueryResult>>
    {
        private readonly IRepository<TicketDocument> _repository;

        public GetTicketDocumentQueryHandler(IRepository<TicketDocument> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTicketDocumentQueryResult>> Handle(GetTicketDocumentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTicketDocumentQueryResult
            {
                Id = x.Id,
                File = x.File,
                CreatedDate = x.CreatedDate,
                TicketId = x.TicketId,
            }).ToList();
        }
    }
}
