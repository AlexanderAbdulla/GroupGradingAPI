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
        public string CourseCrn { get; set; }
        public string CourseTerm { get; set; }
        public string CourseYear { get; set; }

    }
}
