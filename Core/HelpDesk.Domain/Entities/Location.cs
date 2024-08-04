using HelpDesk.Domain.Entities.Common;

namespace HelpDesk.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<StaffDepartment> StaffDepartment { get; set; }
    }
}
