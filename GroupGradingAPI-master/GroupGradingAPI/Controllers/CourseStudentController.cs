using GroupGradingAPI.Data;
using GroupGradingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;


namespace GroupGradingAPI.Controllers
{
    [EnableCors("AllAccessCors")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GradingContext _context;

        /**
         * CourseStudentController
         *
         * Constructor
         *
         * @param GradingContext context - database context
         * @param UserManager<IdentityUser> userManger - manages user identities
         */
        public CourseStudentController(GradingContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // CREATE VALUES
        /*
         *        [Key]
        public string StudentId { get; set; }

        public string CourseId { get; set; }


        public int CourseCrn { get; set; }
        public string CourseTerm { get; set; }
        public int Courseyear { get; set; }
         */
        /**
         *  Inserts a Student into a Course.
         * @param CourseStudent model - database context
         * @return JSONObject - returns a JSONObject confirming student enrollment; else returns an error
         */
        [HttpPost("create")]
        public ActionResult<string> createCourseStudent([FromBody] CourseStudent model)
        {
            try
            {
                CourseStudent newCourseStudent = new CourseStudent();
                newCourseStudent.StudentId = model.StudentId;
                newCourseStudent.CourseCrn = model.CourseCrn;
                newCourseStudent.CourseTerm = model.CourseTerm;
                newCourseStudent.Courseyear = model.Courseyear;

                _context.CourseStudents.Add(newCourseStudent);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Created New CourseStudent");
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(e.Message);
            }
        }

        /**
         *  Deletes a Student from a Course.
         * @param string studentId - Student ID
         * @param string courseId - Course ID
         * @return JSONObject - returns a JSONObject confirming student removal; else returns an error
         */
        [HttpDelete("delete/{studentId}/{courseCrn}")]
        public ActionResult<string> deleteCourseStudent(string studentId, int courseCrn)
        {
            try
            {
                var courseStudent = _context.CourseStudents.Where(c => c.StudentId == studentId && c.CourseCrn == courseCrn).FirstOrDefault();

                _context.CourseStudents.Remove(courseStudent);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Deleted ");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        /**
         * Gets a student from a specific course.
         * @param string studentId - Student ID
         * @param string courseId - Course ID
         * @return JSONObject - returns a JSONObject confirming student was found; else returns an error
         */
        [HttpGet("{studentId}/{courseCrn}")]
        public ActionResult<string> getStudents(string studentId, int courseCrn)
        {
            try
            {
                var courseStudent = _context.CourseStudents.Where(c => c.StudentId == studentId && c.CourseCrn == courseCrn).FirstOrDefault();
                return JsonConvert.SerializeObject(courseStudent);
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        /**
         * Set/Edit student data. NOTE: UNABLE TO EDIT STUDENT ID
         * @param CourseStudent moedl - database context
         * @param string studentId - Student ID
         * @param string courseId - Course ID
         * @return JSONObject - returns a JSONObject confirming student information was changed; else returns an error
         */
        [HttpPut("{studentId}/{courseCrn}")]
        public ActionResult<string> setStudentData([FromBody] CourseStudent model, [FromRoute] string studentId, [FromRoute] int courseCrn)
        {
            try
            {
                var courseStudent = _context.CourseStudents
                    .Where(c => c.StudentId == studentId && c.CourseCrn == courseCrn).FirstOrDefault();

                courseStudent.CourseTerm = model.CourseTerm;
                courseStudent.Courseyear = model.Courseyear;

                _context.CourseStudents.Update(courseStudent);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Success");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        /**
         * Gets a list of all students in specified course.
         * @return JSONObject - returns a list as a JSONObject of all students in specific course; else returns an error
         */
        [HttpGet]
        public ActionResult<string> getCourseStudentData()
        {
            try
            {
                try
                {
                    var courseStudents = _context.CourseStudents.ToList();
                    return JsonConvert.SerializeObject(courseStudents);
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
