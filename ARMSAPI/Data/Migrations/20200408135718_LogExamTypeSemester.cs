using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class LogExamTypeSemester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExaminationTypeId",
                schema: "examination",
                table: "ExaminationAssigningLog",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SemesterId",
                schema: "examination",
                table: "ExaminationAssigningLog",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExaminationTypeId",
                schema: "examination",
                table: "ExaminationAssigningLog");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                schema: "examination",
                table: "ExaminationAssigningLog");
        }
    }
}
