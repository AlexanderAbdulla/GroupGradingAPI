using GroupGradingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupGradingAPI.Data
{
    public class GradingContext : DbContext
    {
        public GradingContext(DbContextOptions options) : base(options) { }

        

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorRole> InstructorRoles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGroup> StudentGroup { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().HasKey(c => c.CourseCrn);
            builder.Entity<Course>().HasKey(c => c.CourseTerm);
            builder.Entity<Course>().HasKey(c => c.CourseYear);

            builder.Entity<CourseStudent>().HasKey(c => c.StudentId);
            builder.Entity<CourseStudent>().HasKey(c => c.CourseId);

            builder.Entity<Student>().HasKey(c => c.StudentId);
            builder.Entity<Student>().HasKey(c => c.CourseId);

        }
    }
}
