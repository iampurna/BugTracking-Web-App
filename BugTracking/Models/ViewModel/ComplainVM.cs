using System;
namespace BugTracking.Models.ViewModel
{
	public class ComplainVM
	{
        public int ComplainInfoID { get; set; }

        public string ComplainNo { get; set; }

        public string Fullname { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }

        public string Statement { get; set; }

        public string Address { get; set; }

        public string CustomerNo { get; set; }
        public DateTime? IssueDate { get; set; }

        public DateTime? CreatedDate { get; set; }



        public List<ComplainStatusTrackInfoVM> TrackInfos { get; set; }
    }
}

