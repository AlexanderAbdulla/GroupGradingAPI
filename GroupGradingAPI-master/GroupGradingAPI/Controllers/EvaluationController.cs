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

namespace GroupGradingAPI.Controllers
{
    [EnableCors("AllAccessCors")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GradingContext _context;

        /**
         * EvaluationController
         *
         * Constructor
         *
         * @param GradingContext context - database context
         * @param UserManager<IdentityUser> userManger - manages user identities
         */
        public EvaluationController(GradingContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        /*
         *         [Key]
        public string EvaluationId { get; set; }


        public string StudentGroupId { get; set; }
        public int CourseCrn { get; set; }
        public string CourseTerm { get; set; }
        public int CourseYear { get; set; }
         */
        /**
         * Inserts a new evaluation into database
         * @param Evaluation model - database context
         * @return JSONObject - returns a JSONObject confirming successful evaluation; else returns an error
         */
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
                newEvaluation.StudentID = model.StudentID;

                _context.Evaluations.Add(newEvaluation);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Created New Evaluation");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        /**
         * Deletes an evaluation from database
         * @param string id - Evaluation ID
         * @return JSONObject - returns a JSONObject confirming successful deletion; else returns an error
         */
        [HttpDelete("delete/{id}")]
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

        /**
         * Gets an evaluation by ID
         * @param string id - Evaluation ID
         * @return JSONObject - returns a JSONObject of specified Evaluation; else returns an error
         */
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

        /**
         * Edits specified evaluation
         * @param Evaluation model - database context
         * @param string id - Evaluation ID
         * @return JSONObject - returns a JSONObject confirming successful changes; else returns an error
         */
        [HttpPut("{id}")]
        public ActionResult<string> seStudentData([FromBody] Evaluation model, [FromRoute] string id)
        {
            try
            {
                var evaluation = _context.Evaluations
                    .Where(c => c.EvaluationId == id).FirstOrDefault();

                evaluation.CourseCrn = model.CourseCrn;
                evaluation.CourseTerm = model.CourseTerm;
                evaluation.CourseYear = model.CourseYear;
                evaluation.EvaluationId = model.EvaluationId;
                evaluation.StudentGroupId = model.StudentGroupId;
                evaluation.StudentID = model.StudentID;

                _context.Evaluations.Update(evaluation);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Success");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        /**
         * Gets all existing evaluations from database
         * @return JSONObject - returns a list of evaluations as a JSONObject; else returns an error
         */
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
