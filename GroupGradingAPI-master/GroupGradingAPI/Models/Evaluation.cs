using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupGradingAPI.Models
{
    public class Evaluation
    {
        [Key]
        public string EvaluationId { get; set; }


        public string StudentGroupId { get; set; }
        public int CourseCrn { get; set; }
        public string CourseTerm { get; set; }
        public int CourseYear { get; set; }
        public string StudentID { get; set; }

    }
}
