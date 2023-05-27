using AuthSystem.Infrastructure;
using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly EmployeeContext _employeeContext;
        StudentController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public JsonResult Index(Students std)
        {
            _employeeContext.Students.Add(std);
            _employeeContext.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message });
         
        }
    }
}
