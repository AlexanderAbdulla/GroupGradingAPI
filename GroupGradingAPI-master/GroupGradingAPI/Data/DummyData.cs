using GroupGradingAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupGradingAPI.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<GradingContext>();
                context.Database.EnsureCreated();

                var _course = DummyData.GetCourses(context).ToArray();
                context.Courses.AddRange(_course);
                context.SaveChanges();

                var _cStudent = DummyData.GetCourseStudents(context).ToArray();
                context.CourseStudents.AddRange(_cStudent);
                context.SaveChanges();

                var _eval = DummyData.GetEvaluations(context).ToArray();
                context.Evaluations.AddRange(_eval);
                context.SaveChanges();

                var _grade = DummyData.GetGrades(context).ToArray();
                context.Grades.AddRange(_grade);
                context.SaveChanges();

                var _sGroup = DummyData.GetStudentGroups(context).ToArray();
                context.StudentGroup.AddRange(_sGroup);
                context.SaveChanges();
            }
        }

        public static List<Course> GetCourses(GradingContext db)
        {
            List<Course> _courses = new List<Course>()
            {
              new Course
              {
                  CourseTerm="Testing", CourseYear=2018,CourseName="COMPTHAT", InstructorId="Medhatid"
              }
            };
            return _courses;
        }

        public static List<CourseStudent> GetCourseStudents(GradingContext db)
        {
            List<CourseStudent> _courses = new List<CourseStudent>()
            {
              new CourseStudent
              {
                  CourseId="testest", CourseCrn=1234,CourseTerm="CourseThing", Courseyear=2017
              }
            };
            return _courses;
        }

        public static List<Evaluation> GetEvaluations(GradingContext db)
        {
            List<Evaluation> _evaluation = new List<Evaluation>()
            {
              new Evaluation
              {
                  StudentGroupId="groupthese", CourseCrn=1234,CourseTerm="CourseThing", CourseYear=2017
              }
            };
            return _evaluation;
        }

        public static List<Grade> GetGrades(GradingContext db)
        {
            List<Grade> _grade = new List<Grade>()
            {
              new Grade
              {
                  StudentId ="a0012345", Percentage=23.6
              }
            };
            return _grade;
        }

        public static List<StudentGroup> GetStudentGroups(GradingContext db)
        {
            List<StudentGroup> _student = new List<StudentGroup>()
            {
              new StudentGroup
              {
                  EvaluationId="candy",CourseId="coooooourse",StudentId="a0012345"
              }
            };
            return _student;
        }
    }

}
