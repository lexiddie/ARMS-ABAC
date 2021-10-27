using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddStudyPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyPlans",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurriculumVersionId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    TotalCredit = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlans_CurriculumVersions_CurriculumVersionId",
                        column: x => x.CurriculumVersionId,
                        principalSchema: "curriculum",
                        principalTable: "CurriculumVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyCourses",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudyPlanId = table.Column<long>(nullable: false),
                    CourseId = table.Column<long>(nullable: true),
                    NameEn = table.Column<string>(maxLength: 100, nullable: false),
                    NameTh = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyCourses_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalSchema: "curriculum",
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyCourses_CourseId",
                schema: "curriculum",
                table: "StudyCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyCourses_StudyPlanId",
                schema: "curriculum",
                table: "StudyCourses",
                column: "StudyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_CurriculumVersionId",
                schema: "curriculum",
                table: "StudyPlans",
                column: "CurriculumVersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyCourses",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "StudyPlans",
                schema: "curriculum");
        }
    }
}
