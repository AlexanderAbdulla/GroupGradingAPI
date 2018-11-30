using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupGradingAPI.Models
{
    public class StudentGroup
    {
        [Key]
        public string GroupName { get; set; }
        public string EvaluationId { get; set; }
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public int CourseCrn { get; set; }
        public List<CourseStudent> Students { get; set; }
    }
}
