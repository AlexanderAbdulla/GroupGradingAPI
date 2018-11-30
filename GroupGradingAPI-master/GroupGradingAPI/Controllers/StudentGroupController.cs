using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupGradingAPI.Data;
using GroupGradingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupGradingAPI.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGroupController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GradingContext _context;

        public StudentGroupController(GradingContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // CREATE VALUES
        
        [EnableCors("AllAccessCors")]
        [HttpPost("create")]
        public ActionResult<string> createEvaluation([FromBody] StudentGroup model)
        {
            try
            {
                StudentGroup newStudentGroup = new StudentGroup();
                newStudentGroup.CourseId = model.CourseId;
                newStudentGroup.EvaluationId = model.EvaluationId;
                newStudentGroup.GroupName = model.GroupName;
                newStudentGroup.StudentId = model.StudentId;


                _context.StudentGroup.Add(newStudentGroup);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Created New StudentGroup");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        // DELETE VALUES
        [EnableCors("AllAccessCors")]
        [HttpDelete("delete/{id}")]
        public ActionResult<string> deleteStudentGroup(string id)
        {
            try
            {
                var studentGroup = _context.StudentGroup.Where(c => c.GroupName == id).FirstOrDefault();

                _context.StudentGroup.Remove(studentGroup);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Deleted ");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        [EnableCors("AllAccessCors")]
        // GET VALUE BY ID
        [HttpGet("{id}")]
        public ActionResult<string> getEvaluations(string id)
        {
            try
            {
                var studentGroup = _context.StudentGroup.Where(c => c.GroupName == id).FirstOrDefault();
                return JsonConvert.SerializeObject(studentGroup);
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }


        [EnableCors("AllAccessCors")]
        //EDIT VALUES
        [HttpPut("{id}")]
        public ActionResult<string> setStudentData([FromBody] StudentGroup model, [FromRoute] string id)
        {
            try
            {
                var studentGroup = _context.StudentGroup
                    .Where(c => c.GroupName == id).FirstOrDefault();

                studentGroup.CourseId = model.CourseId;
                studentGroup.EvaluationId = model.EvaluationId;
               
                studentGroup.StudentId = model.StudentId;
              
                
                _context.StudentGroup.Update(studentGroup);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Success");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        [EnableCors("AllAccessCors")]
        //GET ALL
        [HttpGet]
        public ActionResult<string> getEvaluationData()
        {
            try
            {
                try
                {
                    var studentGroups = _context.StudentGroup.ToList();
                    return JsonConvert.SerializeObject(studentGroups);
                }
                catch (Exception e)
                {

                }
                return JsonConvert.SerializeObject("Error");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }
    }
}
