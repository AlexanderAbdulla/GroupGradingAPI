using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroupGradingAPI.Data;
using GroupGradingAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace GroupGradingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GradingContext _context;

        public StudentsController(GradingContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // CREATE VALUES
        
        [EnableCors("AllAccessCors")]
        [HttpPost("create")]
        public ActionResult<string> createCourse([FromBody] Student model)
        {
            try
            {
                Student newStudent = new Student();
                newStudent.StudentId = model.StudentId;
                newStudent.CourseId = model.CourseId;
                newStudent.LastName = model.LastName;
                newStudent.FirstName = model.FirstName;
                _context.Students.Add(newStudent);
                _context.SaveChanges();
                return JsonConvert.SerializeObject("Created New Student");
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }

        // DELETE VALUES
        [EnableCors("AllAccessCors")]
        [HttpPost("delete/{id}")]
        public ActionResult<string> deleteStudent(string id)
        {
            try
            {
                var student = _context.Students.Where(c => c.StudentId == id).FirstOrDefault();

                _context.Students.Remove(student);
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
        public ActionResult<string> getStudents(string id)
        {
            try
            {
                var student = _context.Students.Where(c => c.StudentId == id).FirstOrDefault();
                return JsonConvert.SerializeObject(student);
            }
            catch (Exception e)
            {

            }
            return JsonConvert.SerializeObject("Error");
        }


        [EnableCors("AllAccessCors")]
        //EDIT VALUES
        [HttpPost("{id}")]
        public ActionResult<string> seStudentData([FromBody] Student model, string id)
        {
            try
            {
                var student = _context.Students
                    .Where(c => c.StudentId == id).FirstOrDefault();

                /*
                course.CourseName = model.CourseName;
                course.CourseTerm = model.CourseTerm;
                course.CourseYear = model.CourseYear;
                */
                _context.Students.Update(student);
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
        public ActionResult<string> getStudentData()
        {
            try
            {
                try
                {
                    var students = _context.Students.ToList();
                    return JsonConvert.SerializeObject(students);
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