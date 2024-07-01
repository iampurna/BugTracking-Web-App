using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracking.Models
{
	public class ComplainInfo
	{
       
        [Key]
        public int ComplainInfoID { get; set; }

        [Required]
        [StringLength(50)]
        public string ComplainNo { get; set; }  // This will be auto-generated

        [Required]
        [StringLength(100)]
        public string Fullname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string ContactNo { get; set; }

        public string Statement { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerNo { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime CreatedDate { get; set; }



        public int ComplainTypeID { get; set; }  // Foreign key
        public ComplainType ComplainType { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
    }
}

