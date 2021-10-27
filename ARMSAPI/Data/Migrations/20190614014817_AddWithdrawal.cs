using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddWithdrawal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "withdrawal");

            migrationBuilder.CreateTable(
                name: "WithdrawalExceptions",
                schema: "withdrawal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacultyId = table.Column<long>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    CourseId = table.Column<long>(nullable: true),
                    StudentId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalExceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithdrawalExceptions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WithdrawalExceptions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WithdrawalExceptions_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WithdrawalExceptions_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalPeriods",
                schema: "withdrawal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    SemesterId = table.Column<long>(nullable: false),
                    Type = table.Column<string>(maxLength: 1, nullable: false),
                    StartedAt = table.Column<DateTime>(nullable: false),
                    EndedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithdrawalPeriods_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Withdrawals",
                schema: "withdrawal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudyCourseId = table.Column<long>(nullable: false),
                    Type = table.Column<string>(maxLength: 1, nullable: false),
                    RequestedAt = table.Column<DateTime>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    InstructorId = table.Column<long>(nullable: true),
                    StudentId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdrawals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Withdrawals_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Withdrawals_StudentStudyCourses_StudyCourseId",
                        column: x => x.StudyCourseId,
                        principalTable: "StudentStudyCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalExceptions_CourseId",
                schema: "withdrawal",
                table: "WithdrawalExceptions",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalExceptions_DepartmentId",
                schema: "withdrawal",
                table: "WithdrawalExceptions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalExceptions_FacultyId",
                schema: "withdrawal",
                table: "WithdrawalExceptions",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalExceptions_StudentId",
                schema: "withdrawal",
                table: "WithdrawalExceptions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawalPeriods_SemesterId",
                schema: "withdrawal",
                table: "WithdrawalPeriods",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_StudentId",
                schema: "withdrawal",
                table: "Withdrawals",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_StudyCourseId",
                schema: "withdrawal",
                table: "Withdrawals",
                column: "StudyCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WithdrawalExceptions",
                schema: "withdrawal");

            migrationBuilder.DropTable(
                name: "WithdrawalPeriods",
                schema: "withdrawal");

            migrationBuilder.DropTable(
                name: "Withdrawals",
                schema: "withdrawal");
        }
    }
}
