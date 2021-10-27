using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AlterExamSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationSlot_Courses_CourseId",
                schema: "master",
                table: "ExaminationSlot");

            migrationBuilder.DropIndex(
                name: "IX_ExaminationSlot_CourseId",
                schema: "master",
                table: "ExaminationSlot");

            migrationBuilder.DropColumn(
                name: "CourseId",
                schema: "master",
                table: "ExaminationSlot");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                schema: "master",
                table: "ExaminationSlot",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationSlot_CourseId",
                schema: "master",
                table: "ExaminationSlot",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationSlot_Courses_CourseId",
                schema: "master",
                table: "ExaminationSlot",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
