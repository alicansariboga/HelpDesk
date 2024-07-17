namespace HelpDesk.Application.Features.Mediator.Handlers.TicketStatusHandlers
{
    public class CreateTicketStatusCommandHandler : IRequestHandler<CreateTicketStatusCommand>
    {
        private readonly IRepository<TicketStatus> _repository;

        public CreateTicketStatusCommandHandler(IRepository<TicketStatus> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTicketStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TicketStatus
            {
                Name = request.Name,
            });
        }
    }
}
