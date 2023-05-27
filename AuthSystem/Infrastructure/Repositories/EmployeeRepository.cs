using AuthSystem.Models;

namespace AuthSystem.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
       private readonly IEmployeeRepository _employeeRepository;
        public EmployeeRepository(EmployeeContext employeeRepository)
        {
            _employeeContext = employeeRepository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _employeeContext.employees.Find(id);
        }

        public async Task <Employee> Insert(Employee employee)
        {
           await _employeeContext.employees.AddAsync(employee);
           await _employeeContext.SaveChangesAsync();
            return employee;
        }

        public Employee Upadate(Employee employee)
        {
            _employeeContext.Update(employee);
            _employeeContext.SaveChangesAsync();
            return employee;
        }
        //public Task<int> Delete(Employee emp)
        //{
        //    _employeeContext.employees.Remove(emp);
        //   return _employeeContext.SaveChangesAsync();
           
        //}

        public Employee Delete(int id)
        {
           Employee employee= _employeeContext.employees.Find(id);
            try
            {
                if(employee != null)
                {
                    _employeeContext.employees.Remove(employee);
                    _employeeContext.SaveChangesAsync();
                    
                }
                return employee;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
