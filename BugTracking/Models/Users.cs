using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracking.Models
{
	public class Users
	{
        [Key]
        public int UsersID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserGroupID { get; set; }
        public int Status { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
    }
}

