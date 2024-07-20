
using HelpDesk.Application.Interfaces;
using HelpDesk.Application.Interfaces.TicketInterfaces;

namespace HelpDesk.Application.Features.Mediator.Handlers.TicketHandlers
{
    public class GetTicketByUserIdQueryHandler : IRequestHandler<GetTicketByUserIdQuery, List<GetTicketByUserIdQueryResult>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketByUserIdQueryHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<GetTicketByUserIdQueryResult>> Handle(GetTicketByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _ticketRepository.GetTicketByUserId(request.Id);
            return values.Select(x => new GetTicketByUserIdQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Message = x.Message,
                Sender = x.Sender,
                Receiver = x.Receiver,
                CreatedTime = x.CreatedTime,
                ModifiedTime = x.ModifiedTime,
                Status = x.Status,
            }).ToList();
        }
    }
}
