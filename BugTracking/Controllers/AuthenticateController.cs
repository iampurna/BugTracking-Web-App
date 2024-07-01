
using BugTracking.DAO;
using BugTracking.Models;
using BugTracking.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracking.Controllers
{
    public class AuthenticateController : Controller
    {
        // GET: /<controller>/
        ApplicationDbContext _context;
        public AuthenticateController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Login()
        {
            HttpContext.Session.Remove("USER_INFO");
            return View();
        }

        [HttpPost]
        public JsonResult SignIn([FromBody] LoginVM vm)
        {
            Users usr = _context.Users
                 .Where(x => x.Status == 1
                  && x.Username == vm.Username
                  && x.Password == vm.Password
                 )
                 .FirstOrDefault();
            if (usr == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "User Not Found"
                });
            }
            else
            {
                HttpContext.Session.SetString("USER_INFO", usr.UsersID.ToString());

                return Json(new
                {
                    Success = true,
                });
            }
        }
    }
}

