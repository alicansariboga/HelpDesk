using HelpDesk.Application.Features.Mediator.Results.StaffDepartmentResults;

namespace HelpDesk.Application.Features.Mediator.Queries.StaffDepartmentQueries
{
    public class GetStaffDepartmentByUserIdQuery : IRequest<GetStaffDepartmentByUserIdQueryResult>
    {
        public GetStaffDepartmentByUserIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
