
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketRouteHandlers
{
    public class GetTicketRouteByIdQueryHandler : IRequestHandler<GetTicketRouteByIdQuery, GetTicketRouteByIdQueryResult>
    {
        private readonly IRepository<TicketRoute> _repository;

        public GetTicketRouteByIdQueryHandler(IRepository<TicketRoute> repository)
        {
            _repository = repository;
        }

        public async Task<GetTicketRouteByIdQueryResult> Handle(GetTicketRouteByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTicketRouteByIdQueryResult
            {
                Id = values.Id,
                TicketId = values.TicketId,
                Description = values.Description,
                Sender = values.Sender,
                Receiver = values.Receiver,
                ModifiedTime = values.ModifiedTime,
            };
        }
    }
}
