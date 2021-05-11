using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject2.Migrations
{
    public partial class Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_StudentUserId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_StudentUserId",
                table: "Courses",
                newName: "IX_Courses_TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                newName: "IX_Courses_StudentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_StudentUserId",
                table: "Courses",
                column: "StudentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
