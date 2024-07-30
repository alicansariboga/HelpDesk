using HelpDesk.Domain.Entities.Common;

namespace HelpDesk.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public List<StaffDepartment> StaffDepartment { get; set; }
    }
}
