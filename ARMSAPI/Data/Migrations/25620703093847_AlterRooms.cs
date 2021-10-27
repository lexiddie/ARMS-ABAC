using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AlterRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCode",
                schema: "master",
                table: "ExaminationRoom");

            migrationBuilder.RenameColumn(
                name: "Rows",
                schema: "master",
                table: "Rooms",
                newName: "ExamRows");

            migrationBuilder.AddColumn<int>(
                name: "ExamCapacity",
                schema: "master",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                schema: "master",
                table: "ExaminationRoom",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationRoom_CourseId",
                schema: "master",
                table: "ExaminationRoom",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationRoom_Courses_CourseId",
                schema: "master",
                table: "ExaminationRoom",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationRoom_Courses_CourseId",
                schema: "master",
                table: "ExaminationRoom");

            migrationBuilder.DropIndex(
                name: "IX_ExaminationRoom_CourseId",
                schema: "master",
                table: "ExaminationRoom");

            migrationBuilder.DropColumn(
                name: "ExamCapacity",
                schema: "master",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CourseId",
                schema: "master",
                table: "ExaminationRoom");

            migrationBuilder.RenameColumn(
                name: "ExamRows",
                schema: "master",
                table: "Rooms",
                newName: "Rows");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                schema: "master",
                table: "ExaminationRoom",
                nullable: true);
        }
    }
}
