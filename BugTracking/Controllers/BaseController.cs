using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracking.Controllers
{
    public class BaseController : Controller
    {
        // GET: /<controller>/
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string ss = HttpContext.Session.GetString("USER_INFO");
            if (string.IsNullOrEmpty(ss))
            {
                context.Result = Redirect("/Authenticate/Login");
            }
        }
    }
}

