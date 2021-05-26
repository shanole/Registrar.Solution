using Microsoft.EntityFrameworkCore.Migrations;

namespace UniRegistrar.Migrations
{
    public partial class AddCourseDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseDescription",
                table: "Courses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseDescription",
                table: "Courses");
        }
    }
}
