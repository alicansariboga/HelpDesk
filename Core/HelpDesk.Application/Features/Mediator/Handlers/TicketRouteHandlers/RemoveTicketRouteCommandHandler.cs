namespace HelpDesk.Application.Features.Mediator.Handlers.TicketRouteHandlers
{
    public class RemoveTicketRouteCommandHandler : IRequestHandler<RemoveTicketRouteCommand>
    {
        private readonly IRepository<TicketRoute> _repository;

        public RemoveTicketRouteCommandHandler(IRepository<TicketRoute> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTicketRouteCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
