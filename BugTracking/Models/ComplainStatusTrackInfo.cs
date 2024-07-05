using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BugTracking.Models.ViewModel;

namespace BugTracking.Models
{
	public class ComplainStatusTrackInfo
	{
        [Key]
        public int ComplainStatusTrackInfoID { get; set; }
        public int ComplainInfoID { get; set; }
        public int TargetStatusID { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }


        

        [ForeignKey("ComplainInfoID")]
        public virtual Complain Complain { get; set; }

        [ForeignKey("TargetStatusID")]
        public virtual ComplainStatus ComplainStatus { get; set; }
    }
}

