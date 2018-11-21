using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupGradingAPI.Models
{
    public class InstructorRole
    {
        [Key]
        public string InstructorRoldeId { get; set; }

        public string Role { get; set; }
    }
}
