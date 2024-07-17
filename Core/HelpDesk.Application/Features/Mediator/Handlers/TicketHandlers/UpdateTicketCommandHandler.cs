
namespace HelpDesk.Application.Features.Mediator.Handlers.TicketHandlers
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
    {
        private readonly IRepository<Ticket> _repository;

        public UpdateTicketCommandHandler(IRepository<Ticket> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Title = request.Title;
            values.Message = request.Message;
            values.Sender = request.Sender;
            values.Receiver = request.Receiver;
            values.CreatedTime = request.CreatedTime;
            values.ModifiedTime = request.ModifiedTime;
            values.Status = request.Status;
            await _repository.UpdateAsync(values);
        }
    }
}
