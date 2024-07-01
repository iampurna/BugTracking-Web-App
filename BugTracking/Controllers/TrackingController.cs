using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracking.DAO;
using BugTracking.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace BugTracking.Controllers
{
    public class TrackingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrackingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IActionResult> Index(string complaintNumber)
        {
            if (!string.IsNullOrEmpty(complaintNumber))
            {
                return Task.FromResult<IActionResult>(RedirectToAction("Dashboard", new { complaintNumber }));
            }

            return Task.FromResult<IActionResult>(View());
        }
        [HttpGet]
        public  IActionResult Dashboard()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetComplainData()
        {
           
            var complainData = _context.ComplainInfos
                .Include(c => c.ComplainType)
                .Select(c => new ComplainInfoViewModel
                {
                    Fullname = c.Fullname,
                    ComplainName = c.ComplainType.ComplainName,
                    Statement = c.Statement,
                    CustomerNo = c.CustomerNo,
                    IsActive = c.IsActive,
                    CreatedDate = c.CreatedDate,
                    Remarks = c.Remarks
                })
                .ToList();

            return Json(new { data = complainData });
        }

        [HttpGet]
        public IActionResult GetComplainInfo()
        {
            var complainInfo = _context.ComplainInfos.ToList();
            return Json(complainInfo);
        }

       
        [HttpGet]
        public IActionResult GetComplainStatus()
        {
            var complainStatus = _context.ComplainStatuses.ToList(); 
            return Json(complainStatus);
        }

        
        [HttpGet]
        public IActionResult GetComplainStatusTrackInfo()
        {
            var complainStatusTrackInfo = _context.ComplainStatusTrackInfos.ToList();
            return Json(complainStatusTrackInfo);
        }


        [HttpGet]
        public IActionResult GetComplainType()
        {
            var complainTypes = _context.ComplainTypes.ToList(); 
            return Json(complainTypes);
        }

    }
}

