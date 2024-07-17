namespace HelpDesk.Application.Features.Mediator.Handlers.TicketStatusHandlers
{
    public class GetTicketStatusByIdQueryHandler : IRequestHandler<GetTicketStatusByIdQuery, GetTicketStatusByIdQueryResult>
    {
        private readonly IRepository<TicketStatus> _repository;

        public GetTicketStatusByIdQueryHandler(IRepository<TicketStatus> repository)
        {
            _repository = repository;
        }

        public async Task<GetTicketStatusByIdQueryResult> Handle(GetTicketStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTicketStatusByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
            };
        }
    }
}
