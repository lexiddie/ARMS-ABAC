using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddCurriculum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "curriculum");

            migrationBuilder.CreateTable(
                name: "Curriculums",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferenceCode = table.Column<string>(maxLength: 50, nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    FacultyId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    SemesterType = table.Column<string>(maxLength: 5, nullable: false),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    AbbreviationEn = table.Column<string>(maxLength: 100, nullable: true),
                    AbbreviationTh = table.Column<string>(maxLength: 100, nullable: true),
                    DescriptionEn = table.Column<string>(maxLength: 500, nullable: true),
                    DescriptionTh = table.Column<string>(maxLength: 500, nullable: true),
                    TotalCredit = table.Column<int>(nullable: false),
                    MinimumGPA = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curriculums_AcademicLevels_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "master",
                        principalTable: "AcademicLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curriculums_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curriculums_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumVersions",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CurriculumId = table.Column<long>(nullable: false),
                    AcademicProgramId = table.Column<long>(nullable: true),
                    ImplementedSemesterId = table.Column<long>(nullable: false),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    OpenedSemesterId = table.Column<long>(nullable: true),
                    ClosedSemesterId = table.Column<long>(nullable: true),
                    MinimumTerm = table.Column<int>(nullable: false),
                    ManximumTerm = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumVersions_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalSchema: "master",
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumVersions_Semesters_ClosedSemesterId",
                        column: x => x.ClosedSemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumVersions_Curriculums_CurriculumId",
                        column: x => x.CurriculumId,
                        principalSchema: "curriculum",
                        principalTable: "Curriculums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumVersions_Semesters_ImplementedSemesterId",
                        column: x => x.ImplementedSemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumVersions_Semesters_OpenedSemesterId",
                        column: x => x.OpenedSemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseGroups",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurriculumVersionId = table.Column<long>(nullable: false),
                    CourseGroupId = table.Column<long>(nullable: true),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    DescriptionEn = table.Column<string>(maxLength: 500, nullable: true),
                    DescriptionTh = table.Column<string>(maxLength: 500, nullable: true),
                    Credit = table.Column<decimal>(nullable: false),
                    MinorId = table.Column<long>(nullable: true),
                    ConcentrationId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseGroups_Concentrations_ConcentrationId",
                        column: x => x.ConcentrationId,
                        principalSchema: "master",
                        principalTable: "Concentrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseGroups_CourseGroups_CourseGroupId",
                        column: x => x.CourseGroupId,
                        principalSchema: "curriculum",
                        principalTable: "CourseGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseGroups_CurriculumVersions_CurriculumVersionId",
                        column: x => x.CurriculumVersionId,
                        principalSchema: "curriculum",
                        principalTable: "CurriculumVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseGroups_Minors_MinorId",
                        column: x => x.MinorId,
                        principalSchema: "master",
                        principalTable: "Minors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumInstructors",
                schema: "curriculum",
                columns: table => new
                {
                    CurriculumVersionId = table.Column<long>(nullable: false),
                    InstructorId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumInstructors", x => new { x.CurriculumVersionId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_CurriculumInstructors_CurriculumVersions_CurriculumVersionId",
                        column: x => x.CurriculumVersionId,
                        principalSchema: "curriculum",
                        principalTable: "CurriculumVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumInstructors_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumCourses",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<long>(nullable: false),
                    CourseGroupId = table.Column<long>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    RequiredGrade = table.Column<string>(maxLength: 5, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumCourses_CourseGroups_CourseGroupId",
                        column: x => x.CourseGroupId,
                        principalSchema: "curriculum",
                        principalTable: "CourseGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurriculumCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroups_ConcentrationId",
                schema: "curriculum",
                table: "CourseGroups",
                column: "ConcentrationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroups_CourseGroupId",
                schema: "curriculum",
                table: "CourseGroups",
                column: "CourseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroups_CurriculumVersionId",
                schema: "curriculum",
                table: "CourseGroups",
                column: "CurriculumVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroups_MinorId",
                schema: "curriculum",
                table: "CourseGroups",
                column: "MinorId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumCourses_CourseGroupId",
                schema: "curriculum",
                table: "CurriculumCourses",
                column: "CourseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumCourses_CourseId",
                schema: "curriculum",
                table: "CurriculumCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumInstructors_InstructorId",
                schema: "curriculum",
                table: "CurriculumInstructors",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_AcademicLevelId",
                schema: "curriculum",
                table: "Curriculums",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_DepartmentId",
                schema: "curriculum",
                table: "Curriculums",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_FacultyId",
                schema: "curriculum",
                table: "Curriculums",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculums_ReferenceCode",
                schema: "curriculum",
                table: "Curriculums",
                column: "ReferenceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVersions_AcademicProgramId",
                schema: "curriculum",
                table: "CurriculumVersions",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVersions_ClosedSemesterId",
                schema: "curriculum",
                table: "CurriculumVersions",
                column: "ClosedSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVersions_CurriculumId",
                schema: "curriculum",
                table: "CurriculumVersions",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVersions_ImplementedSemesterId",
                schema: "curriculum",
                table: "CurriculumVersions",
                column: "ImplementedSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVersions_OpenedSemesterId",
                schema: "curriculum",
                table: "CurriculumVersions",
                column: "OpenedSemesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurriculumCourses",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "CurriculumInstructors",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "CourseGroups",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "CurriculumVersions",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "Curriculums",
                schema: "curriculum");
        }
    }
}
