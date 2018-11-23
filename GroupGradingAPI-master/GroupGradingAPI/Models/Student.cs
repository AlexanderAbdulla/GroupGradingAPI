using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupGradingAPI.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        public string CourseId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
        public string Email { get; set; }

    }
}
