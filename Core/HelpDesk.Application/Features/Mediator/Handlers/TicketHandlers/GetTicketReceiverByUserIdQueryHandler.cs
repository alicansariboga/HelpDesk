using HelpDesk.Application.Interfaces.TicketInterfaces;

namespace HelpDesk.Application.Features.Mediator.Handlers.TicketHandlers
{
    public class GetTicketReceiverByUserIdQueryHandler : IRequestHandler<GetTicketReceiverByUserIdQuery, List<GetTicketReceiverByUserIdQueryResult>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketReceiverByUserIdQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<GetTicketReceiverByUserIdQueryResult>> Handle(GetTicketReceiverByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _ticketRepository.GetTicketReceiverByUserId(request.Id);
            return values.Select(x => new GetTicketReceiverByUserIdQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Message = x.Message,
                Sender = x.Sender,
                Receiver = x.Receiver,
                CreatedTime = x.CreatedTime,
                ModifiedTime = x.ModifiedTime,
                Status = x.Status,
                Value = x.Value
            }).ToList();
        }
    }
}
