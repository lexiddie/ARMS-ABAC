using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARMSAPI.Data.Migrations
{
    public partial class AddStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "student");

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    TitleId = table.Column<long>(nullable: false),
                    FirstNameTh = table.Column<string>(maxLength: 100, nullable: true),
                    FirstNameEn = table.Column<string>(maxLength: 100, nullable: false),
                    LastNameTh = table.Column<string>(maxLength: 100, nullable: true),
                    LastNameEn = table.Column<string>(maxLength: 100, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    RaceId = table.Column<long>(nullable: false),
                    NationalityId = table.Column<long>(nullable: false),
                    ReligionId = table.Column<long>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthProvinceId = table.Column<long>(nullable: true),
                    BirthStateId = table.Column<long>(nullable: true),
                    BirthCountryId = table.Column<long>(nullable: false),
                    CitizenNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Passport = table.Column<string>(maxLength: 20, nullable: true),
                    BankBranchId = table.Column<long>(nullable: true),
                    BankAccount = table.Column<string>(maxLength: 20, nullable: true),
                    AccountUpdatedAt = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    PersonalEmail = table.Column<string>(maxLength: 50, nullable: true),
                    TelephoneNumber1 = table.Column<string>(maxLength: 20, nullable: true),
                    TelephoneNumber2 = table.Column<string>(maxLength: 20, nullable: true),
                    IdCardCreatedDate = table.Column<DateTime>(nullable: false),
                    IdCardExpiredDate = table.Column<DateTime>(nullable: false),
                    RegistrationStatusId = table.Column<long>(nullable: false),
                    StudentRemark = table.Column<string>(maxLength: 1000, nullable: true),
                    ProfileImageURL = table.Column<string>(maxLength: 2100, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_BankBranches_BankBranchId",
                        column: x => x.BankBranchId,
                        principalSchema: "master",
                        principalTable: "BankBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Countries_BirthCountryId",
                        column: x => x.BirthCountryId,
                        principalSchema: "master",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Provinces_BirthProvinceId",
                        column: x => x.BirthProvinceId,
                        principalSchema: "master",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_States_BirthStateId",
                        column: x => x.BirthStateId,
                        principalSchema: "master",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalSchema: "master",
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Races_RaceId",
                        column: x => x.RaceId,
                        principalSchema: "master",
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_RegistrationStatuses_RegistrationStatusId",
                        column: x => x.RegistrationStatusId,
                        principalSchema: "master",
                        principalTable: "RegistrationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalSchema: "master",
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Titles_TitleId",
                        column: x => x.TitleId,
                        principalSchema: "master",
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcademicInformations",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<long>(nullable: false),
                    OldStudentCode = table.Column<string>(maxLength: 20, nullable: true),
                    Batch = table.Column<string>(maxLength: 20, nullable: true),
                    StudentGroupId = table.Column<long>(nullable: false),
                    GPA = table.Column<decimal>(nullable: false),
                    CreditComp = table.Column<int>(nullable: false),
                    CreditExempted = table.Column<int>(nullable: true),
                    CreditEarned = table.Column<int>(nullable: true),
                    CreditLimit = table.Column<int>(nullable: true),
                    CreditTransfer = table.Column<int>(nullable: true),
                    CurriculumVersionId = table.Column<long>(nullable: true),
                    AcademicProgramId = table.Column<long>(nullable: false),
                    AcademicLevelId = table.Column<long>(nullable: false),
                    DegreeName = table.Column<string>(maxLength: 200, nullable: true),
                    FacultyId = table.Column<long>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: true),
                    MinorId = table.Column<long>(nullable: true),
                    SecondMinorId = table.Column<long>(nullable: true),
                    ConcentrationId = table.Column<long>(nullable: true),
                    SecondConcentrationId = table.Column<long>(nullable: true),
                    ScholarshipId = table.Column<long>(nullable: true),
                    IsAthlete = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_AcademicLevels_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "master",
                        principalTable: "AcademicLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalSchema: "master",
                        principalTable: "AcademicPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_Concentrations_ConcentrationId",
                        column: x => x.ConcentrationId,
                        principalSchema: "master",
                        principalTable: "Concentrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_CurriculumVersions_CurriculumVersionId",
                        column: x => x.CurriculumVersionId,
                        principalSchema: "curriculum",
                        principalTable: "CurriculumVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "master",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "master",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_Minors_MinorId",
                        column: x => x.MinorId,
                        principalSchema: "master",
                        principalTable: "Minors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_Scholarships_ScholarshipId",
                        column: x => x.ScholarshipId,
                        principalSchema: "master",
                        principalTable: "Scholarships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_Concentrations_SecondConcentrationId",
                        column: x => x.SecondConcentrationId,
                        principalSchema: "master",
                        principalTable: "Concentrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_Minors_SecondMinorId",
                        column: x => x.SecondMinorId,
                        principalSchema: "master",
                        principalTable: "Minors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_StudentGroups_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalSchema: "master",
                        principalTable: "StudentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicInformations_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionInformations",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<long>(nullable: false),
                    PreviousSchoolId = table.Column<long>(nullable: true),
                    EducationBackgroundId = table.Column<long>(nullable: true),
                    PreviousGraduatedYear = table.Column<int>(nullable: true),
                    PreviousSchoolGPA = table.Column<decimal>(nullable: true),
                    AdmissionTypeId = table.Column<long>(nullable: false),
                    AdmissionSemesterId = table.Column<long>(nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    CheckDated = table.Column<DateTime>(nullable: false),
                    CheckReferenceNumber = table.Column<string>(maxLength: 200, nullable: true),
                    ReplyDate = table.Column<DateTime>(nullable: false),
                    ReplyReferenceNumber = table.Column<string>(maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionInformations_Semesters_AdmissionSemesterId",
                        column: x => x.AdmissionSemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionInformations_AdmissionTypes_AdmissionTypeId",
                        column: x => x.AdmissionTypeId,
                        principalSchema: "master",
                        principalTable: "AdmissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionInformations_EducationBackgrounds_EducationBackgroundId",
                        column: x => x.EducationBackgroundId,
                        principalSchema: "master",
                        principalTable: "EducationBackgrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionInformations_PreviousSchools_PreviousSchoolId",
                        column: x => x.PreviousSchoolId,
                        principalSchema: "master",
                        principalTable: "PreviousSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionInformations_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheatingStatuses",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<long>(nullable: false),
                    CourseId = table.Column<long>(nullable: false),
                    SectionId = table.Column<long>(nullable: false),
                    ExaminationTypeId = table.Column<long>(nullable: false),
                    IncidentId = table.Column<long>(nullable: true),
                    FromSemesterId = table.Column<long>(nullable: true),
                    ToSemesterId = table.Column<long>(nullable: true),
                    PaidStatus = table.Column<bool>(nullable: false),
                    Detail = table.Column<string>(maxLength: 500, nullable: true),
                    ApprovedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ApprovedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheatingStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheatingStatuses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheatingStatuses_ExaminationTypes_ExaminationTypeId",
                        column: x => x.ExaminationTypeId,
                        principalSchema: "master",
                        principalTable: "ExaminationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheatingStatuses_Semesters_FromSemesterId",
                        column: x => x.FromSemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheatingStatuses_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalSchema: "master",
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheatingStatuses_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheatingStatuses_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheatingStatuses_Semesters_ToSemesterId",
                        column: x => x.ToSemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GraduationInformations",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<long>(nullable: false),
                    GraduatedDate = table.Column<DateTime>(nullable: true),
                    Class = table.Column<string>(maxLength: 100, nullable: true),
                    SemesterId = table.Column<long>(nullable: true),
                    HonorId = table.Column<long>(nullable: true),
                    Remark = table.Column<string>(maxLength: 500, nullable: true),
                    ThesisRemark = table.Column<string>(maxLength: 500, nullable: true),
                    OtherRemark1 = table.Column<string>(maxLength: 1000, nullable: true),
                    OtherRemark2 = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraduationInformations_AcademicHonors_HonorId",
                        column: x => x.HonorId,
                        principalSchema: "master",
                        principalTable: "AcademicHonors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GraduationInformations_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GraduationInformations_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceStatuses",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<long>(nullable: false),
                    SemesterId = table.Column<long>(nullable: false),
                    MaintenanceFeeId = table.Column<long>(nullable: false),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    InvoiceNumber = table.Column<string>(maxLength: 200, nullable: true),
                    ApprovedBy = table.Column<string>(maxLength: 200, nullable: true),
                    ApprovedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceStatuses_MaintenanceFees_MaintenanceFeeId",
                        column: x => x.MaintenanceFeeId,
                        principalSchema: "master",
                        principalTable: "MaintenanceFees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceStatuses_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalSchema: "master",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceStatuses_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParentInformations",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    RelationshipId = table.Column<long>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    MailToParent = table.Column<bool>(nullable: false),
                    EmailToParent = table.Column<bool>(nullable: false),
                    SMSToParent = table.Column<bool>(nullable: false),
                    TelephoneNumber1 = table.Column<string>(maxLength: 20, nullable: false),
                    TelephoneNumber2 = table.Column<string>(maxLength: 20, nullable: true),
                    AddressTh = table.Column<string>(maxLength: 500, nullable: true),
                    AddressEn = table.Column<string>(maxLength: 500, nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    ProvinceId = table.Column<long>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    SubdistrictId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    StateId = table.Column<long>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentInformations_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "master",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentInformations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "master",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentInformations_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "master",
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentInformations_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "master",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentInformations_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalSchema: "master",
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentInformations_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "master",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentInformations_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentInformations_Subdistricts_SubdistrictId",
                        column: x => x.SubdistrictId,
                        principalSchema: "master",
                        principalTable: "Subdistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<long>(nullable: false),
                    AddressEn = table.Column<string>(maxLength: 500, nullable: true),
                    AddressTh = table.Column<string>(maxLength: 500, nullable: true),
                    CountryId = table.Column<long>(nullable: false),
                    ProvinceId = table.Column<long>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    SubdistrictId = table.Column<long>(nullable: true),
                    CityId = table.Column<long>(nullable: true),
                    StateId = table.Column<long>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: false),
                    TelephoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Type = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "master",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "master",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalSchema: "master",
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "master",
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "master",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Subdistricts_SubdistrictId",
                        column: x => x.SubdistrictId,
                        principalSchema: "master",
                        principalTable: "Subdistricts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentIncidents",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<long>(nullable: false),
                    IncidentId = table.Column<long>(nullable: false),
                    LockedDocument = table.Column<bool>(nullable: false),
                    LockedRegistration = table.Column<bool>(nullable: false),
                    LockedPayment = table.Column<bool>(nullable: false),
                    LockedVisa = table.Column<bool>(nullable: false),
                    LockedGraduation = table.Column<bool>(nullable: false),
                    LockedChangeFaculty = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIncidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentIncidents_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalSchema: "master",
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentIncidents_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_AcademicLevelId",
                schema: "student",
                table: "AcademicInformations",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_AcademicProgramId",
                schema: "student",
                table: "AcademicInformations",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_ConcentrationId",
                schema: "student",
                table: "AcademicInformations",
                column: "ConcentrationId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_CurriculumVersionId",
                schema: "student",
                table: "AcademicInformations",
                column: "CurriculumVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_DepartmentId",
                schema: "student",
                table: "AcademicInformations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_FacultyId",
                schema: "student",
                table: "AcademicInformations",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_MinorId",
                schema: "student",
                table: "AcademicInformations",
                column: "MinorId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_ScholarshipId",
                schema: "student",
                table: "AcademicInformations",
                column: "ScholarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_SecondConcentrationId",
                schema: "student",
                table: "AcademicInformations",
                column: "SecondConcentrationId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_SecondMinorId",
                schema: "student",
                table: "AcademicInformations",
                column: "SecondMinorId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_StudentGroupId",
                schema: "student",
                table: "AcademicInformations",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInformations_StudentId",
                schema: "student",
                table: "AcademicInformations",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionInformations_AdmissionSemesterId",
                schema: "student",
                table: "AdmissionInformations",
                column: "AdmissionSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionInformations_AdmissionTypeId",
                schema: "student",
                table: "AdmissionInformations",
                column: "AdmissionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionInformations_EducationBackgroundId",
                schema: "student",
                table: "AdmissionInformations",
                column: "EducationBackgroundId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionInformations_PreviousSchoolId",
                schema: "student",
                table: "AdmissionInformations",
                column: "PreviousSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionInformations_StudentId",
                schema: "student",
                table: "AdmissionInformations",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheatingStatuses_CourseId",
                schema: "student",
                table: "CheatingStatuses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CheatingStatuses_ExaminationTypeId",
                schema: "student",
                table: "CheatingStatuses",
                column: "ExaminationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CheatingStatuses_FromSemesterId",
                schema: "student",
                table: "CheatingStatuses",
                column: "FromSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CheatingStatuses_IncidentId",
                schema: "student",
                table: "CheatingStatuses",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_CheatingStatuses_SectionId",
                schema: "student",
                table: "CheatingStatuses",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CheatingStatuses_StudentId",
                schema: "student",
                table: "CheatingStatuses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CheatingStatuses_ToSemesterId",
                schema: "student",
                table: "CheatingStatuses",
                column: "ToSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationInformations_HonorId",
                schema: "student",
                table: "GraduationInformations",
                column: "HonorId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationInformations_SemesterId",
                schema: "student",
                table: "GraduationInformations",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationInformations_StudentId",
                schema: "student",
                table: "GraduationInformations",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceStatuses_MaintenanceFeeId",
                schema: "student",
                table: "MaintenanceStatuses",
                column: "MaintenanceFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceStatuses_SemesterId",
                schema: "student",
                table: "MaintenanceStatuses",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceStatuses_StudentId",
                schema: "student",
                table: "MaintenanceStatuses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInformations_CityId",
                schema: "student",
                table: "ParentInformations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInformations_CountryId",
                schema: "student",
                table: "ParentInformations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInformations_DistrictId",
                schema: "student",
                table: "ParentInformations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInformations_ProvinceId",
                schema: "student",
                table: "ParentInformations",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInformations_RelationshipId",
                schema: "student",
                table: "ParentInformations",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInformations_StateId",
                schema: "student",
                table: "ParentInformations",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInformations_StudentId",
                schema: "student",
                table: "ParentInformations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentInformations_SubdistrictId",
                schema: "student",
                table: "ParentInformations",
                column: "SubdistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_CityId",
                schema: "student",
                table: "StudentAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_CountryId",
                schema: "student",
                table: "StudentAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_DistrictId",
                schema: "student",
                table: "StudentAddresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_ProvinceId",
                schema: "student",
                table: "StudentAddresses",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_StateId",
                schema: "student",
                table: "StudentAddresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_StudentId",
                schema: "student",
                table: "StudentAddresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_SubdistrictId",
                schema: "student",
                table: "StudentAddresses",
                column: "SubdistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidents_IncidentId",
                schema: "student",
                table: "StudentIncidents",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIncidents_StudentId",
                schema: "student",
                table: "StudentIncidents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BankBranchId",
                schema: "student",
                table: "Students",
                column: "BankBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BirthCountryId",
                schema: "student",
                table: "Students",
                column: "BirthCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BirthProvinceId",
                schema: "student",
                table: "Students",
                column: "BirthProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BirthStateId",
                schema: "student",
                table: "Students",
                column: "BirthStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Code",
                schema: "student",
                table: "Students",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_NationalityId",
                schema: "student",
                table: "Students",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RaceId",
                schema: "student",
                table: "Students",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RegistrationStatusId",
                schema: "student",
                table: "Students",
                column: "RegistrationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ReligionId",
                schema: "student",
                table: "Students",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TitleId",
                schema: "student",
                table: "Students",
                column: "TitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicInformations",
                schema: "student");

            migrationBuilder.DropTable(
                name: "AdmissionInformations",
                schema: "student");

            migrationBuilder.DropTable(
                name: "CheatingStatuses",
                schema: "student");

            migrationBuilder.DropTable(
                name: "GraduationInformations",
                schema: "student");

            migrationBuilder.DropTable(
                name: "MaintenanceStatuses",
                schema: "student");

            migrationBuilder.DropTable(
                name: "ParentInformations",
                schema: "student");

            migrationBuilder.DropTable(
                name: "StudentAddresses",
                schema: "student");

            migrationBuilder.DropTable(
                name: "StudentIncidents",
                schema: "student");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "student");
        }
    }
}
