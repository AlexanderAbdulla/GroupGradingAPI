using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupGradingAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseCrn = table.Column<string>(nullable: false),
                    CourseTerm = table.Column<string>(nullable: false),
                    CourseYear = table.Column<string>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    InstructorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseYear);
                    table.UniqueConstraint("AK_Courses_CourseCrn", x => x.CourseCrn);
                    table.UniqueConstraint("AK_Courses_CourseTerm", x => x.CourseTerm);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: false),
                    CourseCrn = table.Column<string>(nullable: true),
                    CourseTerm = table.Column<string>(nullable: true),
                    Courseyear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => x.CourseId);
                    table.UniqueConstraint("AK_CourseStudents_StudentId", x => x.StudentId);
                    table.UniqueConstraint("AK_CourseStudents_CourseId_StudentId", x => new { x.CourseId, x.StudentId });
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    EvaluationId = table.Column<string>(nullable: false),
                    StudentGroupId = table.Column<string>(nullable: true),
                    CourseCrn = table.Column<string>(nullable: true),
                    CourseTerm = table.Column<string>(nullable: true),
                    CourseYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.EvaluationId);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<string>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    Percentage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "InstructorRoles",
                columns: table => new
                {
                    InstructorRoldeId = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorRoles", x => x.InstructorRoldeId);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    InstructorRoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroup",
                columns: table => new
                {
                    GroupName = table.Column<string>(nullable: false),
                    EvaluationId = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroup", x => x.GroupName);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.CourseId);
                    table.UniqueConstraint("AK_Students_StudentId", x => x.StudentId);
                    table.UniqueConstraint("AK_Students_CourseId_StudentId", x => new { x.CourseId, x.StudentId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "InstructorRoles");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "StudentGroup");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
