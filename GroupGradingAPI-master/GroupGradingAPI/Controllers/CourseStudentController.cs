using GroupGradingAPI.Data;
using GroupGradingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupGradingAPI.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GradingContext _context;

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
        [EnableCors("AllAccessCors")]
        [HttpPost("create")]
        public ActionResult<string> createCourseStudent([FromBody] CourseStudent model)
        {
            try
            {
                CourseStudent newCourseStudent = new CourseStudent();
                newCourseStudent.StudentId = model.StudentId;
                newCourseStudent.CourseId = model.CourseId;
                newCourseStudent.CourseCrn = model.CourseCrn;
                newCourseStudent.CourseTerm = model.CourseTerm;
                newCourseStudent.Courseyear = model.Courseyear;
                
                _context.CourseStudents.Add(newCourseStudent);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Created New CourseStudent");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        // DELETE VALUES
        [EnableCors("AllAccessCors")]
        [HttpPost("delete/{studentId}/{courseId}")]
        public ActionResult<string> deleteCourseStudent(string studentId, string courseId)
        {
            try
            {
                var courseStudent = _context.CourseStudents.Where(c => c.StudentId == studentId && c.CourseId == courseId).FirstOrDefault();

                _context.CourseStudents.Remove(courseStudent);
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
        [HttpGet("{studentId}/{courseId}")]
        public ActionResult<string> getStudents(string studentId, string courseId)
        {
            try
            {
                var courseStudent = _context.CourseStudents.Where(c => c.StudentId == studentId && c.CourseId == courseId).FirstOrDefault();
                return JsonConvert.SerializeObject(courseStudent);
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }


        [EnableCors("AllAccessCors")]
        //EDIT VALUES
        //CANNOT EDIT STUDENT ID 
        [HttpPut("{studentId}/{courseId}")]
        public ActionResult<string> setStudentData([FromBody] CourseStudent model, [FromRoute] string studentId, [FromRoute] string courseId)
        {
            try
            {
                var courseStudent = _context.CourseStudents
                    .Where(c => c.StudentId == studentId && c.CourseId == courseId).FirstOrDefault();



                courseStudent.CourseId = model.CourseId;
                courseStudent.CourseCrn = model.CourseCrn;
                courseStudent.CourseTerm = model.CourseTerm;
                courseStudent.Courseyear = model.Courseyear;
                //courseStudent.StudentId = model.StudentId;

                _context.CourseStudents.Update(courseStudent);
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

