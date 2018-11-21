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

                /*
                var ailments = GetAilments().ToArray();
                context.Ailments.AddRange(ailments);
                context.SaveChanges();
                */

                var students = GetStudents().ToArray();
                context.Students.AddRange(students);
                context.SaveChanges();

                
            }
        }

        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>() {
                new Student {StudentId="a00123", CourseId="a1", FirstName = "Alex", LastName = "Abdulla", Email = "none of your business" }
            };
            return students;
        }
        
        
    }
}
