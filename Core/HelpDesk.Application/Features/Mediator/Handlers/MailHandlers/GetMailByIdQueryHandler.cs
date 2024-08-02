namespace HelpDesk.Application.Features.Mediator.Handlers.MailHandlers
{
    public class GetMailByIdQueryHandler : IRequestHandler<GetMailByIdQuery, GetMailByIdQueryResult>
    {
        private readonly IRepository<Mail> _repository;

        public GetMailByIdQueryHandler(IRepository<Mail> repository)
        {
            _repository = repository; 
        }

        public async Task<GetMailByIdQueryResult> Handle(GetMailByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetMailByIdQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Message = values.Message,
                Sender = values.Sender,
                Receiver = values.Receiver,
                CreatedTime = values.CreatedTime,
                ModifiedTime = values.ModifiedTime,
                IsRead = values.IsRead,
            };
        }
    }
}
