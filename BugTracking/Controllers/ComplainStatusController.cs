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
    public class ComplainStatusController : Controller
    {
        ApplicationDbContext _context;
        public ComplainStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult GetAllComplainStatus()
        {
            var data = _context.ComplainStatus.Where(x => x.IsActive == true)
                 .Select(s => new
                 {
                     ComplainStausID = s.ComplainStatusID,
                     StatusName = s.StatusName
                 })
                 .ToList();

            return Json(new
            {
                Success = true,
                Data = data
            });
        }


        [HttpPost]
        public JsonResult Create([FromBody] ComplainStatusTrackInfoVM model)
        {
            ComplainStatusTrackInfo obj = new ComplainStatusTrackInfo();

            obj.ComplainInfoID = model.ComplainInfoID;
            obj.TargetStatusID = model.TargetStatusID;
            obj.Remarks = model.Remarks;
            obj.CreatedBy = 1;
            obj.CreatedDate = DateTime.Now;

            _context.ComplainStatusTrackInfo.Add(obj);
            _context.SaveChanges();


            return Json(new
            {
                Success = true,
                Message = "Complain Status Tracked Successfully..."
            });
        }
    }
}

