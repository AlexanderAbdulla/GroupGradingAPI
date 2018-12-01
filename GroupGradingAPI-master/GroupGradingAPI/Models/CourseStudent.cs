using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupGradingAPI.Models
{
    public class CourseStudent
    {
        [Key]
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public int CourseCrn { get; set; }
        public string CourseTerm { get; set; }
        public int Courseyear { get; set; }


    }
}
