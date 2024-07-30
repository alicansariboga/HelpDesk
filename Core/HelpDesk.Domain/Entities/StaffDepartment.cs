using HelpDesk.Domain.Entities.Common;

namespace HelpDesk.Domain.Entities
{
    public class StaffDepartment : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
