using HelpDesk.Application.Interfaces.MailInterfaces;

namespace HelpDesk.Application.Features.Mediator.Handlers.MailHandlers
{
    public class GetMailAdminByUserIdQueryHandler : IRequestHandler<GetMailAdminByUserIdQuery, List<GetMailAdminByUserIdQueryResult>>
    {
        private readonly IMailRepository _repository;

        public GetMailAdminByUserIdQueryHandler(IMailRepository MailRepository)
        {
            _repository = MailRepository;
        }

        public async Task<List<GetMailAdminByUserIdQueryResult>> Handle(GetMailAdminByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetMailAdminByUserId(request.Id);
            return values.Select(x => new GetMailAdminByUserIdQueryResult
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
