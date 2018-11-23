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
        public string InstructorRoleId { get; set; }

        public string Role { get; set; }
    }
}
