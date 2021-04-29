using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject2.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_StudentUsersId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentUsersId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentUsersId",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CourseStudentUser",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudentUser", x => new { x.CoursesId, x.StudentUsersId });
                    table.ForeignKey(
                        name: "FK_CourseStudentUser_AspNetUsers_StudentUsersId",
                        column: x => x.StudentUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudentUser_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentUser_StudentUsersId",
                table: "CourseStudentUser",
                column: "StudentUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudentUser");

            migrationBuilder.AddColumn<string>(
                name: "StudentUsersId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentUsersId",
                table: "Courses",
                column: "StudentUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_StudentUsersId",
                table: "Courses",
                column: "StudentUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
