namespace HelpDesk.Application.Features.Mediator.Handlers.MailHandlers
{
    public class GetMailQueryHandler : IRequestHandler<GetMailQuery, List<GetMailQueryResult>>
    {
        private readonly IRepository<Mail> _repository;

        public GetMailQueryHandler(IRepository<Mail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetMailQueryResult>> Handle(GetMailQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetMailQueryResult
            {
                Id = x.Id,
                Title = x.Title,
                Message = x.Message,
                Sender = x.Sender,
                Receiver = x.Receiver,
                CreatedTime = x.CreatedTime,
                ModifiedTime = x.ModifiedTime,
                IsRead = x.IsRead,
            }).ToList();
        }
    }
}
