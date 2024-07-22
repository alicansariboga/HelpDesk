
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketHandlers
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, GetTicketByIdQueryResult>
    {
        private readonly IRepository<Ticket> _repository;

        public GetTicketByIdQueryHandler(IRepository<Ticket> repository)
        {
            _repository = repository;
        }

        public async Task<GetTicketByIdQueryResult> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTicketByIdQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Message = values.Message,
                Sender = values.Sender,
                Receiver = values.Receiver,
                CreatedTime = values.CreatedTime,
                ModifiedTime = values.ModifiedTime,
                Status = values.Status,
                Value = values.Value,
            };
        }
    }
}
