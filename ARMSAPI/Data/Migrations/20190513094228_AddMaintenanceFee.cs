using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddMaintenanceFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceFees",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentGroupId = table.Column<long>(nullable: false),
                    SemesterId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    FacultyId = table.Column<long>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    Fee = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceFees_AcademicLevels_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "master",
                        principalTable: "AcademicLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceFees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceFees_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceFees_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceFees_StudentGroups_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalSchema: "master",
                        principalTable: "StudentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceFees_AcademicLevelId",
                schema: "master",
                table: "MaintenanceFees",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceFees_DepartmentId",
                schema: "master",
                table: "MaintenanceFees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceFees_FacultyId",
                schema: "master",
                table: "MaintenanceFees",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceFees_SemesterId",
                schema: "master",
                table: "MaintenanceFees",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceFees_StudentGroupId",
                schema: "master",
                table: "MaintenanceFees",
                column: "StudentGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceFees",
                schema: "master");
        }
    }
}
