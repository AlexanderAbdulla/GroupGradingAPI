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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GradingContext _context;

        public EvaluationController(GradingContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // CREATE VALUES
        /*
         *         [Key]
        public string EvaluationId { get; set; }


        public string StudentGroupId { get; set; }
        public int CourseCrn { get; set; }
        public string CourseTerm { get; set; }
        public int CourseYear { get; set; }
         */
        [EnableCors("AllAccessCors")]
        [HttpPost("create")]
        public ActionResult<string> createEvaluation([FromBody] Evaluation model)
        {
            try
            {
                Evaluation newEvaluation = new Evaluation();
                newEvaluation.CourseCrn = model.CourseCrn;
                newEvaluation.CourseTerm = model.CourseTerm;
                newEvaluation.CourseYear = model.CourseYear;
                newEvaluation.EvaluationId = model.EvaluationId;
                newEvaluation.StudentGroupId = model.StudentGroupId;

                _context.Evaluations.Add(newEvaluation);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Created New Evaluation");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        // DELETE VALUES
        [EnableCors("AllAccessCors")]
        [HttpPost("delete/{id}")]
        public ActionResult<string> deleteEvaluation(string id)
        {
            try
            {
                var evaluation = _context.Evaluations.Where(c => c.EvaluationId == id).FirstOrDefault();

                _context.Evaluations.Remove(evaluation);
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
                var evaluation = _context.Evaluations.Where(c => c.EvaluationId == id).FirstOrDefault();
                return JsonConvert.SerializeObject(evaluation);
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }


        [EnableCors("AllAccessCors")]
        //EDIT VALUES
        [HttpPut("{id}")]
        public ActionResult<string> seStudentData([FromBody] Evaluation model, [FromRoute] string id)
        {
            try
            {
                var evaluation = _context.Evaluations
                    .Where(c => c.EvaluationId == id).FirstOrDefault();

                /*
                course.CourseName = model.CourseName;
                course.CourseTerm = model.CourseTerm;
                course.CourseYear = model.CourseYear;
                */
                _context.Evaluations.Update(evaluation);
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
                    var evaluations = _context.Evaluations.ToList();
                    return JsonConvert.SerializeObject(evaluations);
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
