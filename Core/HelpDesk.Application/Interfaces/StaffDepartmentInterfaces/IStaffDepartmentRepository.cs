namespace HelpDesk.Application.Interfaces.StaffDepartmentInterfaces
{
    public interface IStaffDepartmentRepository
    {
        List<StaffDepartment> GetStaffDepartmentAll();
        StaffDepartment GetStaffDepartmentByUserId(int id);
    }
}
