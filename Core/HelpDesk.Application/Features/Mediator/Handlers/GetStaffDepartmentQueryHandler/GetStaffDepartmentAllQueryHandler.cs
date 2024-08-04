using HelpDesk.Application.Features.Mediator.Queries.StaffDepartmentQueries;
using HelpDesk.Application.Features.Mediator.Results.StaffDepartmentResults;
using HelpDesk.Application.Interfaces.StaffDepartmentInterfaces;

namespace HelpDesk.Application.Features.Mediator.Handlers.GetStaffDepartmentQueryHandler
{
    public class GetStaffDepartmentAllQueryHandler : IRequestHandler<GetStaffDepartmentAllQuery, List<GetStaffDepartmentAllQueryResult>>
    {
        private readonly IStaffDepartmentRepository _repository;

        public GetStaffDepartmentAllQueryHandler(IStaffDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetStaffDepartmentAllQueryResult>> Handle(GetStaffDepartmentAllQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetStaffDepartmentAll();
            return values.Select(x => new GetStaffDepartmentAllQueryResult
            {
                Id = x.Id,
                DepartmentId = x.DepartmentId,
                DepartmentName = x.Department.Name,
                LocationId = x.LocationId,
                LocationName = x.Location.Name,
                AppUserId = x.AppUserId,
                Name = x.AppUser.Name,
                Surname = x.AppUser.Surname,
                ImageUrl = x.AppUser.ImageUrl,
                UserName = x.AppUser.UserName,
                Email = x.AppUser.Email,
                EmailConfirmed = x.AppUser.EmailConfirmed,
                PhoneNumber = x.AppUser.PhoneNumber,
                PhoneConfirmed = x.AppUser.PhoneConfirmed,
                TwoFactorEnabled = x.AppUser.TwoFactorEnabled,
                FailedLoginCount = x.AppUser.FailedLoginCount,
            }).ToList();
        }
    }
}
