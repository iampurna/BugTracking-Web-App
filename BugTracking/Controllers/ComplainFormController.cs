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
    public class ComplainFormController : Controller
    {
        ApplicationDbContext _context;
        public ComplainFormController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Form()
        {
            return View();
        }
        public IActionResult track()
        {


            return View();

        }
        [HttpGet]
        public JsonResult GetAllData(string CUSTOMERNO)
        {
            List<ComplainVM> u = _context
                            .Complain
                            .Where(x => (string.IsNullOrEmpty(CUSTOMERNO) || x.CustomerNo == CUSTOMERNO))

                            .Select(s => new ComplainVM
                            {
                                ComplainInfoID = s.ComplainInfoID,
                                ComplainNo = s.ComplainNo,
                                Fullname = s.Fullname,
                                Address = s.Address,
                                ContactNo = s.ContactNo,
                                Email = s.Email,
                                Statement = s.Statement,
                                IssueDate = s.IssueDate,
                                CreatedDate = s.CreatedDate,

                            })
                            .ToList();

            return Json(new
            {
                Success = true,
                Data = u
            });
        }
        [HttpGet]
        public JsonResult Create(string CUSTOMERID, string FULLNAME, string ADDRESS, string CONTACTNO, string EMAIL, string STATEMENT, string ISSUEDATE)
        {
            if (string.IsNullOrEmpty(CUSTOMERID))
            {

                return Json(new
                {
                    sucess = false,
                    Message = "Enter Your Customer ID!.."
                });
            }
            else if (string.IsNullOrEmpty(FULLNAME))
            {

                return Json(new
                {
                    sucess = false,
                    Message = "Enter Your FullName!..."
                });
            }
            else if (string.IsNullOrEmpty(ADDRESS))
            {

                return Json(new
                {
                    sucess = false,
                    Message = "Enter Your Address!..."
                });
            }
            else if (string.IsNullOrEmpty(CONTACTNO))
            {

                return Json(new
                {
                    sucess = false,
                    Message = "Enter Your Contact Number!..."
                });
            }
            else if (string.IsNullOrEmpty(EMAIL))
            {

                return Json(new
                {
                    sucess = false,
                    Message = "Enter Your Email Address!..."
                });
            }
            else if (string.IsNullOrEmpty(STATEMENT))
            {

                return Json(new
                {
                    sucess = false,
                    Message = "Enter Your Issue!..."
                });
            }
            else if (string.IsNullOrEmpty(ISSUEDATE))
            {

                return Json(new
                {
                    sucess = false,
                    Message = "Enter Your Issue Occur Date!..."
                });
            }
            else
            {
                string cmp = "CMP-" + (_context.Complain.Count() + 1).ToString();
                Complain c = new Complain
                {
                    ComplainNo = cmp,
                    CustomerNo = CUSTOMERID,
                    Fullname = FULLNAME,
                    Address = ADDRESS,
                    Email = EMAIL,
                    ContactNo = CONTACTNO,
                    Statement = STATEMENT,
                    IssueDate = DateTime.Parse(ISSUEDATE),
                    CreatedDate = DateTime.Now
                };

                _context.Complain.Add(c);
                _context.SaveChanges();


                ComplainStatusTrackInfo ti = new ComplainStatusTrackInfo()
                {
                    ComplainInfoID = c.ComplainInfoID,
                    TargetStatusID = 1,
                    Remarks = "",
                    CreatedBy = 0,
                    CreatedDate = DateTime.Now
                };

                _context.ComplainStatusTrackInfo.Add(ti);
                _context.SaveChanges();


                return Json(new
                {
                    Success = true,
                    Message = "Complain Submitted Successfully... Your Complain No is: " + c.ComplainNo
                });
            }

        }

        [HttpGet]
        public JsonResult GetByComplainNo(string no, int id)
        {
            ComplainVM complain = _context.Complain
                .Where(x =>
                       (string.IsNullOrEmpty(no) || x.ComplainNo == no)
                       && (id == 0 || x.ComplainInfoID == id)
                )
                .Select(s => new ComplainVM
                {
                    Address = s.Address,
                    ComplainInfoID = s.ComplainInfoID,
                    ComplainNo = s.ComplainNo,
                    ContactNo = s.ContactNo,
                    CreatedDate = s.CreatedDate,
                    CustomerNo = s.CustomerNo,
                    Email = s.Email,
                    Fullname = s.Fullname,
                    IssueDate = s.IssueDate,
                    Statement = s.Statement,
                })
                .FirstOrDefault();


            if (complain == null)
            {
                return Json(new
                {
                    success = false,
                    Message = "Complain Info Not Found..."
                });
            }
            else
            {
                complain.TrackInfos = _context.ComplainStatusTrackInfo
                .Where(x => x.ComplainInfoID == complain.ComplainInfoID)
                .Select(s => new ComplainStatusTrackInfoVM
                {
                    ComplainInfoID = s.ComplainInfoID,
                    ComplainStatusTrackInfoID = s.ComplainStatusTrackInfoID,
                    CreatedBy = s.CreatedBy,
                    CreatedDate = s.CreatedDate,
                    Remarks = s.Remarks.ToString(),
                    TargetStatusID = s.TargetStatusID,
                    TargetStatusName = s.ComplainStatus.StatusName,
                    TargetStatusCode = s.ComplainStatus.StatusCode
                })
                .ToList();

                return Json(new
                {
                    success = true,
                    Message = "Complain Info Found...",
                    Data = complain
                });
            }
        }
    }
}

