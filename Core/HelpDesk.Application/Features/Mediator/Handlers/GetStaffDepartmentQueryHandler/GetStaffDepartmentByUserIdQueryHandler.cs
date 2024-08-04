using HelpDesk.Application.Features.Mediator.Queries.StaffDepartmentQueries;
using HelpDesk.Application.Features.Mediator.Results.StaffDepartmentResults;
using HelpDesk.Application.Interfaces.StaffDepartmentInterfaces;
using HelpDesk.Application.Interfaces.TicketInterfaces;
using HelpDesk.Domain.Entities;
using System.Xml.Linq;

namespace HelpDesk.Application.Features.Mediator.Handlers.GetStaffDepartmentQueryHandler
{
    public class GetStaffDepartmentByUserIdQueryHandler : IRequestHandler<GetStaffDepartmentByUserIdQuery, GetStaffDepartmentByUserIdQueryResult>
    {
        private readonly IStaffDepartmentRepository _repository;

        public GetStaffDepartmentByUserIdQueryHandler(IStaffDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetStaffDepartmentByUserIdQueryResult> Handle(GetStaffDepartmentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetStaffDepartmentByUserId(request.Id);
            return new GetStaffDepartmentByUserIdQueryResult
            {
                Id = values.Id,
                DepartmentId = values.DepartmentId,
                DepartmentName = values.Department.Name,
                LocationId = values.LocationId,
                LocationName = values.Location.Name,
                LocationAddress = values.Location.Address,
                AppUserId = values.AppUserId,
                Name = values.AppUser.Name,
                Surname = values.AppUser.Surname,
                ImageUrl = values.AppUser.ImageUrl,
                UserName = values.AppUser.UserName,
                Email = values.AppUser.Email,
                EmailConfirmed = values.AppUser.EmailConfirmed,
                PhoneNumber = values.AppUser.PhoneNumber,
                PhoneConfirmed = values.AppUser.PhoneConfirmed,
                TwoFactorEnabled = values.AppUser.TwoFactorEnabled,
                FailedLoginCount = values.AppUser.FailedLoginCount,
            };
        }
    }
}
