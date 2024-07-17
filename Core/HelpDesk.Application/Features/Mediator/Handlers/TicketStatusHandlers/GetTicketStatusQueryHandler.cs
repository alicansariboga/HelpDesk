
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketStatusHandlers
{
    public class GetTicketStatusQueryHandler : IRequestHandler<GetTicketStatusQuery, List<GetTicketStatusQueryResult>>
    {
        private readonly IRepository<TicketStatus> _repository;

        public GetTicketStatusQueryHandler(IRepository<TicketStatus> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTicketStatusQueryResult>> Handle(GetTicketStatusQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTicketStatusQueryResult
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
