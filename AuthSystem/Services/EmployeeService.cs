using AuthSystem.Models;

namespace AuthSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    
        public IEnumerable<Employee> GetAllValues()
        {
            var employees = _employeeRepository.GetAll();
            return employees;
        }
    }
}
