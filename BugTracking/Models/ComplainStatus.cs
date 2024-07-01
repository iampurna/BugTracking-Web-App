using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracking.Models
{
	public class ComplainStatus
	{
        [Key]
        public int ComplainStatusID { get; set; }

        [Required]
        [StringLength(100)]
        public string StatusName { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("User")]
        public int CreatedBy { get; set; }
    }
}

