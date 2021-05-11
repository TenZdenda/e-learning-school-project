using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject2.Migrations
{
    public partial class seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Courses",
                newName: "TeacherUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherUserId",
                table: "Courses",
                newName: "UserId");
        }
    }
}
