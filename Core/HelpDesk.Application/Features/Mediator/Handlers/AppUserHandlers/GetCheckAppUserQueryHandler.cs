namespace HelpDesk.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;
        private readonly IRepository<AppUserRole> _appUserRoleRepository;

        public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository, IRepository<AppUserRole> appUserRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
            _appUserRoleRepository = appUserRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);
            if (user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.Username = user.UserName;
                values.AppUserId = user.Id;
                //values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleID == user.AppRoleID)).Name;
                var userRole = await _appUserRoleRepository.GetByFilterAsync(x => x.AppUserId == user.Id);
                values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.Id == userRole.AppRoleId)).Name;
            }
            return values;
        }
    }
}
