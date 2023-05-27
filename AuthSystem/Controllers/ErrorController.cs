using AuthSystem.Areas.Identity.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;

        public ErrorController(ILogger<ErrorController> logger , Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        [Route("Error/{statusCode}")]    
        public IActionResult httpErrorHandler(int statusCode)
        {
            try
            {
                _logger.LogInformation("API started at:" + DateTime.Now);
                var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

                switch (statusCode)
                {
                    case 404:
                        ViewBag.ErrorMessage = "Sorry the resources You Requested, Can't Found";

                        _logger.LogWarning($"404 Error Occured Path={statusCodeResult.OriginalPath}" +
                            $"And Query String ={statusCodeResult.OriginalQueryString}");
                        //ViewBag.Path = statusCodeResult.OriginalPath;
                        //ViewBag.QS = statusCodeResult.OriginalQueryString;
                        break;

                }
                
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
            }
            return View("NotFound");
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult GlobalError()
        {
            var exceptionDetails=HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"The Path{exceptionDetails.Path}threw an exception" +
                $"{exceptionDetails.Error}");
            //ViewBag.ExceptionPath = exceptionDetails.Path;
            //ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            //ViewBag.Stacktrace = exceptionDetails.Error.StackTrace;
            return View("GlobalError");
        }
     
     

    }
}
