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
                //context.Database.Migrate();

                // Look for any ailments
                if (context.Students != null && context.Students.Any())
                    return;   // DB has already been seeded             

                storeStudentGroups(context);
                storeStudents(context);
                storeCourses(context);
                storeCStudents(context);
                storeEvaluations(context);
                storeGrades(context);
                storeInstructors(context);
                storeInstructorRoles(context);
            }
        }

        private static void storeStudentGroups(GradingContext context)
        {
            var groups = GetStudentGroups().ToArray();
            context.StudentGroup.AddRange(groups);
            context.SaveChanges();
        }

        private static List<StudentGroup> GetStudentGroups()
        {
            List<StudentGroup> groups = new List<StudentGroup>()
            {
                new StudentGroup {GroupName="Team Pie",EvaluationId="547",StudentId="a00123", CourseId="a1"}
            };
            return groups;
        }

        private static void storeInstructorRoles(GradingContext context)
        {
            var roles = GetRoles().ToArray();
            context.InstructorRoles.AddRange(roles);
            context.SaveChanges();
        }

        private static List<InstructorRole> GetRoles()
        {
            List<InstructorRole> roles = new List<InstructorRole>()
            {
                new InstructorRole {InstructorRoleId="a00777",Role="Teacher"}
            };
            return roles;
        }

        private static void storeInstructors(GradingContext context)
        {
            var instructors = GetInstructors().ToArray();
            context.Instructors.AddRange(instructors);
            context.SaveChanges();
        }

        private static List<Instructor> GetInstructors()
        {
            List<Instructor> instructors = new List<Instructor>()
            {
                new Instructor {InstructorId="a00999",FirstName="Teacher",LastName="LastDude",Password="password",Email="Something@somewhere.ca",InstructorRoleId="a00555"}
            };
            return instructors;
        }

        private static void storeCourses(GradingContext context)
        {
            var courses = GetCourses().ToArray();
            context.Courses.AddRange(courses);
            context.SaveChanges();
        }

        private static void storeCStudents(GradingContext context)
        {
            var cStudent = GetCStudent().ToArray();
            context.CourseStudents.AddRange(cStudent);
            context.SaveChanges();
        }

        private static void storeGrades(GradingContext context)
        {
            var grades = GetGrades().ToArray();
            context.Grades.AddRange(grades);
            context.SaveChanges();
        }

        private static void storeEvaluations(GradingContext context)
        {
            var eval = GetEvaluations().ToArray();
            context.Evaluations.AddRange(eval);
            context.SaveChanges();
        }

        private static void storeStudents(GradingContext context)
        {
            var students = GetStudents().ToArray();
            context.Students.AddRange(students);
            context.SaveChanges();
        }

        public static List<Grade> GetGrades()
        {
            List<Grade> grades = new List<Grade>()
            {
                new Grade {GradeId="GradeId",StudentId="a00123", Percentage=82.78},
                new Grade {GradeId="GradeId2",StudentId="a00456", Percentage=42.0},
                new Grade {GradeId="GradeId3",StudentId="a00789", Percentage=96.28},
                new Grade {GradeId="GradeId4",StudentId="a00111", Percentage=12.31}
            };
            return grades;
        }

        public static List<Evaluation> GetEvaluations()
        {
            List<Evaluation> evals = new List<Evaluation>()
            {
                new Evaluation {EvaluationId="EvalId", StudentGroupId="1234", CourseCrn=1234, CourseTerm="Something",CourseYear=2018}
            };
            return evals;
        }

        public static List<CourseStudent> GetCStudent()
        {
            List<CourseStudent> students = new List<CourseStudent>()
            {
                new CourseStudent {StudentId="a00123", CourseId="a1", CourseCrn=1234, CourseTerm="Something", Courseyear=2018},
                new CourseStudent {StudentId="a00456", CourseId="a1", CourseCrn=1234, CourseTerm="Something", Courseyear=2018},
                new CourseStudent {StudentId="a00789", CourseId="a1", CourseCrn=1234, CourseTerm="Something", Courseyear=2018},
                new CourseStudent {StudentId="a00111", CourseId="a1", CourseCrn=1234, CourseTerm="Something", Courseyear=2018}
            };
            return students;
        }

        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student {StudentId="a00123", CourseId="a1", FirstName = "Alex", LastName = "Abdulla", Email = "none@none.com" },
                new Student {StudentId="a00456", CourseId="a1", FirstName = "Ryan", LastName = "Joseph", Email = "something@mail.com" },
                new Student {StudentId="a00789", CourseId="a1", FirstName = "Garel", LastName = "Bucknor", Email = "school@school.ca" },
                new Student {StudentId="a00111", CourseId="a1", FirstName = "John", LastName = "Pie", Email = "pumpkin@pie.com" }
            };
            return students;
        }

        public static List<Course> GetCourses()
        {
            List<Course> course = new List<Course>()
            {
                new Course {CourseCrn =1234, CourseTerm="Something", CourseYear=2018,CourseName="COMP1510", InstructorId="A001234"}
            };
            return course;
        }
    }
}
