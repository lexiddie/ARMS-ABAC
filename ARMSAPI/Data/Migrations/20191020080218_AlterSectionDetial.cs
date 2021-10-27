using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AlterSectionDetial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CampusId",
                table: "SectionDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SectionDetails_CampusId",
                table: "SectionDetails",
                column: "CampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_SectionDetails_Campuses_CampusId",
                table: "SectionDetails",
                column: "CampusId",
                principalSchema: "master",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionDetails_Campuses_CampusId",
                table: "SectionDetails");

            migrationBuilder.DropIndex(
                name: "IX_SectionDetails_CampusId",
                table: "SectionDetails");

            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "SectionDetails");
        }
    }
}
