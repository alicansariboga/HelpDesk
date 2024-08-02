using HelpDesk.Application.Interfaces.MailInterfaces;

namespace HelpDesk.Application.Features.Mediator.Handlers.MailHandlers
{
    public class GetMailByUserIdQueryHandler : IRequestHandler<GetMailByUserIdQuery, List<GetMailByUserIdQueryResult>>
    {
        private readonly IMailRepository _repository;

        public GetMailByUserIdQueryHandler(IMailRepository MailRepository)
        {
            _repository = MailRepository;
        }

        public async Task<List<GetMailByUserIdQueryResult>> Handle(GetMailByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetMailByUserId(request.Id);
            return values.Select(x => new GetMailByUserIdQueryResult
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
