using HelpDesk.Domain.Entities.Common;

namespace HelpDesk.Domain.Entities
{
    public class AppRole : BaseEntity
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
