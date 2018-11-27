using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupGradingAPI.Data;
using GroupGradingAPI.Models;
using GroupGradingAPI.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GroupGradingAPI.Controllers
{
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
        [HttpPost("{id}")]
        public ActionResult<string> setCourseData([FromBody] SetCourseViewModel model, int id)
        {
            try
            {
                var course = _context.Courses.Where(c => c.CourseCrn == id).FirstOrDefault();
                course.CourseName = model.CourseName;
                course.CourseTerm = model.CourseTerm;
                course.CourseYear = model.CourseYear;
                _context.Courses.Update(course);
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