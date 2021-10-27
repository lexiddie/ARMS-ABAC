using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddUniversity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campuses",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    Address1En = table.Column<string>(maxLength: 500, nullable: true),
                    Address2En = table.Column<string>(maxLength: 500, nullable: true),
                    Address1Th = table.Column<string>(maxLength: 500, nullable: true),
                    Address2Th = table.Column<string>(maxLength: 500, nullable: true),
                    CountryId = table.Column<long>(nullable: false),
                    ProvinceId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    SubdistrictId = table.Column<long>(nullable: false),
                    Zipcode = table.Column<string>(maxLength: 10, nullable: false),
                    TelephoneNumber1 = table.Column<string>(maxLength: 20, nullable: false),
                    TelephoneNumber2 = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campuses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "master",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campuses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "master",
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campuses_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "master",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campuses_Subdistricts_SubdistrictId",
                        column: x => x.SubdistrictId,
                        principalSchema: "master",
                        principalTable: "Subdistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    NameTh = table.Column<string>(maxLength: 500, nullable: false),
                    NameEn = table.Column<string>(maxLength: 500, nullable: false),
                    ShortNameTh = table.Column<string>(maxLength: 200, nullable: true),
                    ShortNameEn = table.Column<string>(maxLength: 200, nullable: true),
                    Abbreviation = table.Column<string>(maxLength: 50, nullable: true),
                    LogoURL = table.Column<string>(maxLength: 2100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameEn = table.Column<string>(maxLength: 200, nullable: false),
                    NameTh = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    FloorNumber = table.Column<int>(nullable: false),
                    CampusId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Campuses_CampusId",
                        column: x => x.CampusId,
                        principalSchema: "master",
                        principalTable: "Campuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    NameTh = table.Column<string>(maxLength: 500, nullable: false),
                    NameEn = table.Column<string>(maxLength: 500, nullable: false),
                    ShortNameTh = table.Column<string>(maxLength: 200, nullable: true),
                    ShortNameEn = table.Column<string>(maxLength: 200, nullable: true),
                    Abbreviation = table.Column<string>(maxLength: 50, nullable: true),
                    LogoURL = table.Column<string>(maxLength: 2100, nullable: true),
                    FacultyId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    BuildingId = table.Column<long>(nullable: false),
                    RoomTypeId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "master",
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalSchema: "master",
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Concentrations",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    NameTh = table.Column<string>(maxLength: 500, nullable: false),
                    NameEn = table.Column<string>(maxLength: 500, nullable: false),
                    ShortNameTh = table.Column<string>(maxLength: 200, nullable: true),
                    ShortNameEn = table.Column<string>(maxLength: 200, nullable: true),
                    FacultyId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concentrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concentrations_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Concentrations_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Minors",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    NameTh = table.Column<string>(maxLength: 500, nullable: false),
                    NameEn = table.Column<string>(maxLength: 500, nullable: false),
                    ShortNameTh = table.Column<string>(maxLength: 200, nullable: true),
                    ShortNameEn = table.Column<string>(maxLength: 200, nullable: true),
                    FacultyId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Minors_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CampusId",
                schema: "master",
                table: "Buildings",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_Code",
                schema: "master",
                table: "Campuses",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_CountryId",
                schema: "master",
                table: "Campuses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_DistrictId",
                schema: "master",
                table: "Campuses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_ProvinceId",
                schema: "master",
                table: "Campuses",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_SubdistrictId",
                schema: "master",
                table: "Campuses",
                column: "SubdistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Concentrations_Code",
                schema: "master",
                table: "Concentrations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concentrations_DepartmentId",
                schema: "master",
                table: "Concentrations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Concentrations_FacultyId",
                schema: "master",
                table: "Concentrations",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Code",
                schema: "master",
                table: "Departments",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                schema: "master",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Code",
                schema: "master",
                table: "Faculties",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Minors_Code",
                schema: "master",
                table: "Minors",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Minors_DepartmentId",
                schema: "master",
                table: "Minors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Minors_FacultyId",
                schema: "master",
                table: "Minors",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingId",
                schema: "master",
                table: "Rooms",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                schema: "master",
                table: "Rooms",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concentrations",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Minors",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Buildings",
                schema: "master");

            migrationBuilder.DropTable(
                name: "RoomTypes",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Faculties",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Campuses",
                schema: "master");
        }
    }
}
