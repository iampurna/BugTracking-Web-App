using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracking.Models
{
	public class Complain
	{
        [Key]
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

    }
}

