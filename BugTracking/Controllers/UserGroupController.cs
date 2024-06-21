using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracking.DAO;
using BugTracking.Models;
using BugTracking.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugTracking.Controllers
{
    public class UserGroupController : BaseController
    {

        ApplicationDbContext _context;
        public UserGroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create([FromBody] UserGroup ui)
        {
            if (string.IsNullOrEmpty(ui.UserGroupName))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Enter User Group Name..."
                });

            }
            else if (string.IsNullOrEmpty(ui.UserGroupCode))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Enter User Group Code..."
                });
            }
            else
            {
                if (ui.UserGroupID == 0)
                {
                    //add part i.e. create new user group
                    UserGroup oldCode = _context.UserGroup
                         .Where(x => x.UserGroupCode == ui.UserGroupCode)
                         .FirstOrDefault();

                    if (oldCode == null)
                    {
                        UserGroup ug = new UserGroup()
                        {
                            UserGroupName = ui.UserGroupName,
                            UserGroupCode = ui.UserGroupCode,
                            Status = 1,
                            ActivateDate = DateTime.Now
                        };

                        _context.UserGroup.Add(ug);
                        _context.SaveChanges();

                        return Json(new
                        {
                            Success = true,
                            Message = "User Group Added Successfully..."
                        });
                    }
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "User Group Code Already Exist..."
                        });
                    }
                }
                else
                {
                    // update part
                    UserGroup oldGrp = _context.UserGroup.Where(x => x.UserGroupID == ui.UserGroupID).FirstOrDefault();
                    if (oldGrp == null)
                    {
                        return Json(new
                        {
                            Success = false,
                            Message = "User Group Information Not Found..."
                        });
                    }
                    else
                    {
                        oldGrp.UserGroupName = ui.UserGroupName;
                        oldGrp.UserGroupCode = ui.UserGroupCode;

                        _context.SaveChanges();

                        return Json(new
                        {
                            Success = true,
                            Message = "User Group Information Updated Successfully..."
                        });
                    }
                }
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            UserGroup oldGroup = _context.UserGroup.Where(x => x.UserGroupID == id).FirstOrDefault();
            if (oldGroup == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "User Group Information Not Found..."
                });
            }
            else
            {
                oldGroup.Status = 0;
                _context.SaveChanges();


                return Json(new
                {
                    Success = true,
                    Message = "User Group Information Deleted Successfully..."
                });
            }
        }

        [HttpGet]
        public JsonResult GetAllData(string grpname, string grpcode)
        {
            List<UserGroupVM> ugs = _context
                .UserGroup
                .Where(x => x.Status == 1
                   && (string.IsNullOrEmpty(grpname) || x.UserGroupName.Contains(grpname))  // grpname = admin
                   && (string.IsNullOrEmpty(grpcode) || x.UserGroupCode.Contains(grpcode))  // grpname = admin
                )
                .Select(s => new UserGroupVM
                {
                    UserGroupID = s.UserGroupID,
                    UserGroupName = s.UserGroupName,
                    UserGroupCode = s.UserGroupCode,
                    ActivateDate = s.ActivateDate.Value.ToString("yyyy/MM/dd")
                })
                .ToList();

            return Json(new
            {
                Success = true,
                Data = ugs
            });
        }

        [HttpGet]
        public JsonResult GetByID(int id)
        {
            UserGroup ug = _context.UserGroup.Where(x => x.UserGroupID == id).FirstOrDefault();
            if (ug == null)
            {
                return Json(new
                {
                    Success = false,
                    Message = "User Group Information Not Found..."
                });
            }
            else
            {
                return Json(new
                {
                    Success = true,
                    Data = ug
                });
            }
        }

    }
}

