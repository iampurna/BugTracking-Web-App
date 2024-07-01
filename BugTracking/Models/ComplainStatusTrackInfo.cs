using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracking.Models
{
	public class ComplainStatusTrackInfo
	{
        [Key]
        public int ComplainStatusTrackInfoID { get; set; }

        [ForeignKey("ComplainInfo")]
        public int ComplainInfoID { get; set; }

        [ForeignKey("ComplainStatus")]
        public int TargetStatusID { get; set; }

        public string Remarks { get; set; }

        [ForeignKey("User")]
        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

