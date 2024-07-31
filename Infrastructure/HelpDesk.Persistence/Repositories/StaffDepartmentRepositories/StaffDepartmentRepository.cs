using HelpDesk.Application.Interfaces.StaffDepartmentInterfaces;
using HelpDesk.Persistence.Context;

namespace HelpDesk.Persistence.Repositories.StaffDepartmentRepositories
{
    public class StaffDepartmentRepository : IStaffDepartmentRepository
    {
        private readonly HelpDeskContext _context;
        public StaffDepartmentRepository(HelpDeskContext context)
        {
            _context = context;
        }

        public List<StaffDepartment> GetStaffDepartmentAll()
        {
            return _context.StaffDepartments.Include(x => x.AppUser).Include(x => x.Department).Include(x => x.Location).ToList();
        }

        public StaffDepartment GetStaffDepartmentByUserId(int id)
        {
            return _context.StaffDepartments.Where(x => x.AppUserId == id).Include(x => x.AppUser).Include(x => x.Department).Include(x => x.Location).FirstOrDefault();
        }
    }
}
