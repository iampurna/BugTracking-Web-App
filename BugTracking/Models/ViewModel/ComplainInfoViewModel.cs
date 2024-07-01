using System;
namespace BugTracking.Models.ViewModel
{
    public class ComplainInfoViewModel
    {
        public string Fullname { get; set; }
        public string ComplainName { get; set; }
        public string Statement { get; set; }
        public string CustomerNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Remarks { get; set; }
    }
}

