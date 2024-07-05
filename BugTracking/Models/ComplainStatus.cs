using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracking.Models
{
	public class ComplainStatus
	{
        [Key]
        public int ComplainStatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}

