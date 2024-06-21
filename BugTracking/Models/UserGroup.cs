using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracking.Models
{
	public class UserGroup
	{
        [Key]
        public int UserGroupID { get; set; }
        public string UserGroupName { get; set; }
        public string UserGroupCode { get; set; }
        public DateTime? ActivateDate { get; set; }
        public int Status { get; set; }
    }
}

