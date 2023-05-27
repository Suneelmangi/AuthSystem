namespace AuthSystem.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee>GetAll();
        Employee GetById(int id);
        Task<Employee> Insert(Employee employee);
        Employee Upadate(Employee employee);
        //Task<int> Delete(Employee emp);
        Employee Delete(int id);

    }
}
