using AuthSystem.Areas.Identity.Data;
using AuthSystem.Infrastructure;
using AuthSystem.Models;
using AuthSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace AuthSystem.Controllers
{
   [Authorize]
   // [Route("Account/Index")]
    public class AccountController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMemoryCache _memoryCache;
        
        public AccountController(IEmployeeRepository employeeRepository, UserManager<ApplicationUser> userManager,IMemoryCache memoryCache)
        {
            
            _employeeRepository = employeeRepository;
            _userManager = userManager;
            _memoryCache = memoryCache;
        }

        //public JsonResult SearchData()
        //{
        //    List<Core> li=coreContext.Cores.OrderBy(x => x.Id).ToList();    
        //    return Json(li);
        //}
        public IActionResult Search(string searching)
        {
           var searched = _employeeRepository.GetAll().Where(x => x.Ename.Contains(searching) || searching == null).ToList();
            return View(searched);
        }
        //[Route("Account/ListOfAccounts")]
        //[Route("Account1/ListOfAccounts1")]
        //[Route("Account2/ListOfAccounts2")]
        public IActionResult Index()
        {
           
            try
            {
                var result = _employeeRepository.GetAll().ToList();
                //throw new NullReferenceException("");
                return View(result);
            }
            catch (Exception)
            {
               
                throw;
            }
            
        }

        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create(EmployeeViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employe =await _employeeRepository.Insert(vm.Employee);
                    return Json(new { id = employe.Eid });
                }
                return View(vm);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Get /edit
        public IActionResult Edit(int id)
        {
            var item = _employeeRepository.GetById(id);
           
            return View(item);
        }



        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(Employee item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeRepository.Upadate(item);
                    TempData["Success"] = " The Item Has Been Updated";
                    return RedirectToAction("Index");
                }
                return View(item);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //[HttpGet]
        //[ActionName("Delete")]
        //public IActionResult Delete_get(int id)
        //{
        //    var item = _employeeRepository.GetById(id);

        //    return View(item);
        //}


       
        public IActionResult Delete(int id)
        {
            try
            {
             
                var core = _employeeRepository.Delete(id);
                return RedirectToAction("Index");
         
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Details(int? id)
        {
           
            Employee employee = _employeeRepository.GetById(id.Value);
            if(employee == null)
            {
               // throw new Exception("Error In details view");
                Response.StatusCode = 404;
                return View("EmployeeNotFound",id.Value);  
            }
            try
            {

                var item = employee;// _employeeRepository.GetById(id??1);
                return View(item);
            }
            catch (Exception)
            {

                throw new Exception("Error In Details view");
            }
        }
        
        [AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        public async Task<IActionResult> EmailAlreadyUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email{email} is Already in use");
            }

        }
    }
}

