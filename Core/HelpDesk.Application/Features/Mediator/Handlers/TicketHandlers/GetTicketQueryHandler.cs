namespace HelpDesk.Application.Features.Mediator.Handlers.TicketHandlers
{
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, List<GetTicketQueryResult>>
    {
        private readonly IRepository<Ticket> _repository;

        public GetTicketQueryHandler(IRepository<Ticket> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetTicketQueryResult>> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTicketQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Message = x.Message,
                Sender = x.Sender,
                Receiver = x.Receiver,
                CreatedTime = x.CreatedTime,
                ModifiedTime = x.ModifiedTime,
                Status = x.Status,
                Value = x.Value,
            }).ToList();
        }
    }
}
