
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketRouteHandlers
{
    public class UpdateTicketRouteCommandHandler : IRequestHandler<UpdateTicketRouteCommand>
    {
        private readonly IRepository<TicketRoute> _repository;

        public UpdateTicketRouteCommandHandler(IRepository<TicketRoute> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTicketRouteCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.TicketId = request.TicketId;
            values.Description = request.Description;
            values.Sender = request.Sender;
            values.Receiver = request.Receiver;
            values.ModifiedTime = request.ModifiedTime;
            await _repository.UpdateAsync(values);
        }
    }
}
