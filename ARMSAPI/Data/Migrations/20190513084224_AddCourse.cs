using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    FacultyId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    ShortNameEn = table.Column<string>(maxLength: 80, nullable: false),
                    ShortNameTh = table.Column<string>(maxLength: 80, nullable: false),
                    DescriptionEn = table.Column<string>(maxLength: 500, nullable: true),
                    DescriptionTh = table.Column<string>(maxLength: 500, nullable: true),
                    Credit = table.Column<decimal>(nullable: false),
                    RegistrationCredit = table.Column<decimal>(nullable: false),
                    PaymentCredit = table.Column<decimal>(nullable: false),
                    TeachingTypeId = table.Column<long>(nullable: false),
                    Hour = table.Column<decimal>(nullable: false),
                    Lecture = table.Column<decimal>(nullable: false),
                    Lab = table.Column<decimal>(nullable: false),
                    Other = table.Column<decimal>(nullable: false),
                    WillShowTranscript = table.Column<bool>(nullable: false),
                    WillCalculateCredit = table.Column<bool>(nullable: false),
                    IsIntensiveCourse = table.Column<bool>(nullable: false),
                    IsSectionGroup = table.Column<bool>(nullable: false),
                    MinimumSeat = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AcademicLevels_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "master",
                        principalTable: "AcademicLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_TeachingTypes_TeachingTypeId",
                        column: x => x.TeachingTypeId,
                        principalSchema: "master",
                        principalTable: "TeachingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademicLevelId",
                table: "Courses",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeachingTypeId",
                table: "Courses",
                column: "TeachingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
