
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketStatusHandlers
{
    public class UpdateTicketStatusCommandHandler : IRequestHandler<UpdateTicketStatusCommand>
    {
        private readonly IRepository<TicketStatus> _repository;

        public UpdateTicketStatusCommandHandler(IRepository<TicketStatus> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTicketStatusCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
