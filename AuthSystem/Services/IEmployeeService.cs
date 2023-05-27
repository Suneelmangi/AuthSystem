using AuthSystem.Models;

namespace AuthSystem.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllValues();
    }
}
