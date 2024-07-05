using System;
namespace BugTracking.Models.ViewModel
{
    public class ComplainStatusTrackInfoVM
    {
        public int ComplainStatusTrackInfoID { get; set; }
        public int ComplainInfoID { get; set; }
        public int TargetStatusID { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string TargetStatusName { get; set; }
        public string TargetStatusCode { get; set; }
    }
}

