using AuthSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{
    public class LayeredController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public LayeredController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var result = _employeeService.GetAllValues().ToList();
            return View(result);
        }
    }
}
