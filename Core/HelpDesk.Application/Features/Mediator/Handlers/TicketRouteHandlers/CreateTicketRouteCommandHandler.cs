namespace HelpDesk.Application.Features.Mediator.Handlers.TicketRouteHandlers
{
    public class CreateTicketRouteCommandHandler : IRequestHandler<CreateTicketRouteCommand>
    {
        private readonly IRepository<TicketRoute> _repository;

        public CreateTicketRouteCommandHandler(IRepository<TicketRoute> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTicketRouteCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TicketRoute
            {
                TicketId = request.TicketId,
                Description = request.Description,
                Sender = request.Sender,
                Receiver = request.Receiver,
                ModifiedTime = request.ModifiedTime,
            });
        }
    }
}
