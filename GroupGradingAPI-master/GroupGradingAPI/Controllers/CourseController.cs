using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupGradingAPI.Data;
using GroupGradingAPI.Models;
using GroupGradingAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GroupGradingAPI.Controllers
{
    [Authorize(Roles = "Teacher, Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GradingContext _context;

        public CourseController(GradingContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // CREATE VALUES
        [EnableCors("AllAccessCors")]
        [HttpPost("create")]
        public ActionResult<string> createCourse([FromBody] CreateCourseViewModel model)
        {
            try
            {
                Course newCourse = new Course();
                newCourse.CourseName = model.CourseName;
                newCourse.CourseTerm = model.CourseTerm;
                newCourse.CourseYear = model.CourseYear;
                newCourse.InstructorId = model.InstructorId;
                _context.Courses.Add(newCourse);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Created New Course");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        // DELETE VALUES
        [EnableCors("AllAccessCors")]
        [HttpDelete("delete/{id}")]
        public ActionResult<string> deleteCourse(int id)
        {
            try
            {
                var course = _context.Courses.Where(c => c.CourseCrn == id).FirstOrDefault();
                
                _context.Courses.Remove(course);
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
        public ActionResult<string> getCourse(int id)
        {
            try
            {
                var course = _context.Courses.Where(c => c.CourseCrn == id).FirstOrDefault();
                return JsonConvert.SerializeObject(course);
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }


        [EnableCors("AllAccessCors")]
        //EDIT VALUES
        [HttpPut("{id}")]
        public ActionResult<string> setCourseData([FromBody] Course model, [FromRoute] int id)
        {
            try
            {
                var course = _context.Courses.Where(c => c.CourseCrn == id).FirstOrDefault();
                course.CourseName = model.CourseName;
                course.CourseTerm = model.CourseTerm;
                course.CourseYear = model.CourseYear;
                course.InstructorId = model.InstructorId;
                _context.Courses.Update(course);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Success");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        /// <summary>
        /// Shows all current courses within the database.
        /// </summary>
        [EnableCors("AllAccessCors")]
        [HttpGet]
        public ActionResult<string> getCourseData()
        {
            try
            {
                try
                {
                    var courses = _context.Courses.ToList();
                    return JsonConvert.SerializeObject(courses);
                }
                catch (Exception e)
                {
                    //
                }
                return JsonConvert.SerializeObject("error");
            }
            catch (Exception e)
            {
                //
            }
            return JsonConvert.SerializeObject("Error");
        }
    }
}