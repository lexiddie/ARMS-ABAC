using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AlterCurriculumVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "curriculum",
                table: "CurriculumVersions",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "DegreeAbbreviationEn",
                schema: "curriculum",
                table: "CurriculumVersions",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DegreeAbbreviationTh",
                schema: "curriculum",
                table: "CurriculumVersions",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DegreeNameEn",
                schema: "curriculum",
                table: "CurriculumVersions",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DegreeNameTh",
                schema: "curriculum",
                table: "CurriculumVersions",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreeAbbreviationEn",
                schema: "curriculum",
                table: "CurriculumVersions");

            migrationBuilder.DropColumn(
                name: "DegreeAbbreviationTh",
                schema: "curriculum",
                table: "CurriculumVersions");

            migrationBuilder.DropColumn(
                name: "DegreeNameEn",
                schema: "curriculum",
                table: "CurriculumVersions");

            migrationBuilder.DropColumn(
                name: "DegreeNameTh",
                schema: "curriculum",
                table: "CurriculumVersions");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "curriculum",
                table: "CurriculumVersions",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
