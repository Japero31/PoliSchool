

using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IDepartmentDao
    {
        List<DepartmentModel> GetDepartments();
    }
}
