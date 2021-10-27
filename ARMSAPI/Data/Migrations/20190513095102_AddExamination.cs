using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddExamination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExaminationPeriods",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<long>(nullable: false),
                    SemesterId = table.Column<long>(nullable: false),
                    MidtermDate = table.Column<DateTime>(nullable: false),
                    MidtermStart = table.Column<TimeSpan>(nullable: false),
                    MidtermEnd = table.Column<TimeSpan>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: false),
                    FinalStart = table.Column<TimeSpan>(nullable: false),
                    FinalEnd = table.Column<TimeSpan>(nullable: false),
                    IsEvening = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationPeriods_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationPeriods_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationTypes",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationPeriods_CourseId",
                table: "ExaminationPeriods",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationPeriods_SemesterId",
                table: "ExaminationPeriods",
                column: "SemesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExaminationPeriods");

            migrationBuilder.DropTable(
                name: "ExaminationTypes",
                schema: "master");
        }
    }
}
