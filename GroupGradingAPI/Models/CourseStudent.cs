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

        [Key]
        public string CourseId { get; set; }


        public string CourseCrn { get; set; }
        public string CourseTerm { get; set; }
        public string Courseyear { get; set; }


    }
}
