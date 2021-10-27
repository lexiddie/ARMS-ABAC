using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddAdmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdmissionTypes",
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
                    table.PrimaryKey("PK_AdmissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardExpirationOptions",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    FacultyId = table.Column<long>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    ValidityYear = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardExpirationOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardExpirationOptions_AcademicLevels_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "master",
                        principalTable: "AcademicLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardExpirationOptions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardExpirationOptions_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationBackgrounds",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    CountryId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationBackgrounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationBackgrounds_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "master",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreviousSchools",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    CountryId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousSchools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviousSchools_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "master",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardExpirationOptions_AcademicLevelId",
                schema: "master",
                table: "CardExpirationOptions",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CardExpirationOptions_DepartmentId",
                schema: "master",
                table: "CardExpirationOptions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CardExpirationOptions_FacultyId",
                schema: "master",
                table: "CardExpirationOptions",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationBackgrounds_CountryId",
                schema: "master",
                table: "EducationBackgrounds",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PreviousSchools_Code",
                schema: "master",
                table: "PreviousSchools",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreviousSchools_CountryId",
                schema: "master",
                table: "PreviousSchools",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionTypes",
                schema: "master");

            migrationBuilder.DropTable(
                name: "CardExpirationOptions",
                schema: "master");

            migrationBuilder.DropTable(
                name: "EducationBackgrounds",
                schema: "master");

            migrationBuilder.DropTable(
                name: "PreviousSchools",
                schema: "master");
        }
    }
}
