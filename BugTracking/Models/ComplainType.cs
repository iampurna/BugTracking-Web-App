using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracking.Models
{
	public class ComplainType
	{
        [Key]
        public int ComplainTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string ComplainName { get; set; }

        [Required]
        [StringLength(50)]
        public string ComplainCode { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("User")]
        public int CreatedBy { get; set; }
    }
}

