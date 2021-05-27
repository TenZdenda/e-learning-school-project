using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaCodeAndTown",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoadNameAndNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeacherUser_AreaCodeAndTown",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeacherUser_RoadNameAndNumber",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaCodeAndTown",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoadNameAndNumber",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherUser_AreaCodeAndTown",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherUser_RoadNameAndNumber",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
