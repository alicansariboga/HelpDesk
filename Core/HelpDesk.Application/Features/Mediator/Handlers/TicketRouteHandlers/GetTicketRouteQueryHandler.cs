namespace HelpDesk.Application.Features.Mediator.Handlers.TicketRouteHandlers
{
    public class GetTicketRouteQueryHandler : IRequestHandler<GetTicketRouteQuery, List<GetTicketRouteQueryResult>>
    {
        private readonly IRepository<TicketRoute> _repository;

        public GetTicketRouteQueryHandler(IRepository<TicketRoute> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTicketRouteQueryResult>> Handle(GetTicketRouteQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTicketRouteQueryResult
            {
                Id = x.Id,
                TicketId = x.TicketId,
                Description = x.Description,
                Sender = x.Sender,
                Receiver = x.Receiver,
                ModifiedTime = x.ModifiedTime,
            }).ToList();
        }
    }
}
