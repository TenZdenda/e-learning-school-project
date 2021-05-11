using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject2.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TeacherUserId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherUserId",
                table: "Courses",
                column: "TeacherUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherUserId",
                table: "Courses",
                column: "TeacherUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherUserId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherUserId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherUserId",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
