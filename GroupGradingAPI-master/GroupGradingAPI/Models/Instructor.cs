using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupGradingAPI.Models
{
    public class Instructor
    {
        [Key]
        public string InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Password { get; set; }
        public string Email { get; set; }
        public string InstructorRoleId { get; set; }

    }
}
