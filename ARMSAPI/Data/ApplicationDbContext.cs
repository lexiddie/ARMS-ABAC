using System.Threading.Tasks;
using ARMSAPI.Models.DataModels;
using ARMSAPI.Models.DataModels.MasterTables;
using ARMSAPI.Models.DataModels.Curriculums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ARMSAPI.Models.DataModels.Withdrawals;

namespace ARMSAPI.Data
{   
    public class ApplicationDbContext : IdentityDbContext
    { 
       public ApplicationDbContext() { }

       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
       
       public DbSet<BankBranch> BankBranches { get; set; }
       public DbSet<MaintenanceFee> MaintenanceFees { get; set; }
       public DbSet<Incident> Incidents { get; set; }
       public DbSet<Relationship> Relationships { get; set; } 
       public DbSet<Scholarship> Scholarships { get; set; }
       public DbSet<Semester> Semesters { get; set; }        
        
       #region Admission
       public DbSet<AdmissionType> AdmissionTypes { get; set; }
       public DbSet<CardExpirationOption> CardExpirationOptions { get; set; }
       public DbSet<EducationBackground> EducationBackgrounds { get; set; }
       public DbSet<PreviousSchool> PreviousSchools { get; set; }
       #endregion
        
       #region Academic Calendar
       public DbSet<Event> Events { get; set; }
       public DbSet<EventCategory> EventCategories { get; set; }
       public DbSet<AcademicCalendar> AcademicCalendars { get; set; }
       #endregion

       #region Academic
       public DbSet<AcademicHonor> AcademicHonors { get; set; }
       public DbSet<AcademicLevel> AcademicLevels { get; set; }
       public DbSet<AcademicProgram> AcademicPrograms { get; set; }
       public DbSet<StudentGroup> StudentGroups { get; set; }
       #endregion

       #region Registration
       public DbSet<CreditLoad> CreditLoads { get; set; }
       public DbSet<RegistrationStatus> RegistrationStatuses { get; set; }
       public DbSet<RegistrationResult> RegistrationResults { get; set; }
       public DbSet<RegistrationSlot> RegistrationSlots { get; set; }
       public DbSet<Slot> Slots { get; set; }
       public DbSet<Models.DataModels.StudyCourse> StudentStudyCourses { get; set; }
       #endregion
        
       #region PersonInfo
       public DbSet<Title> Titles { get; set; }
       public DbSet<Nationality> Nationalities { get; set; }
       public DbSet<Race> Races { get; set; }
       public DbSet<Religion> Religions { get; set; }
       #endregion
       
       #region Curriculum
       public DbSet<Curriculum> Curriculums { get; set; }
       public DbSet<CurriculumVersion> CurriculumVersions { get; set; }
       public DbSet<CurriculumCourse> CurriculumCourses { get; set; }
       public DbSet<CurriculumInstructor> CurriculumInstructor { get; set; }
       public DbSet<CourseGroup> CourseGroups { get; set; }
       public DbSet<Models.DataModels.Curriculums.StudyCourse> StudyCourses { get; set; }
       public DbSet<StudyPlan> StudyPlans { get; set; }
       #endregion 

       #region Courses 
       public DbSet<Course> Courses { get; set; }
       public DbSet<Section> Sections { get; set; }
       public DbSet<SectionDetail> SectionDetails { get; set; }
       public DbSet<InstructorSection> InstructorSections { get; set; }
       #endregion

       #region Examination 
       public DbSet<ExaminationType> ExaminationTypes { get; set; }
       public DbSet<ExaminationSlot> ExaminationSlots { get; set; }
       public DbSet<ExaminationRoom> ExaminationRooms { get; set; }
       public DbSet<SeatArrangementResult> SeatArrangementResults { get; set; }
       public DbSet<CourseExaminationSlot>  CourseExaminationSlots { get; set; }
       public DbSet<ExaminationAssigningLog> ExaminationAssigningLogs { get; set; }
       #endregion

       #region Instructor
       public DbSet<Instructor> Instructors { get; set; }
       public DbSet<InstructorWorkStatus> InstructorWorkStatuses { get; set; }
       #endregion

       #region Teaching Load
       public DbSet<TeachingType> TeachingTypes { get; set; }
       public DbSet<TeachingLoad> TeachingLoads { get; set; }
       #endregion

       #region Reason
       public DbSet<ReEnterReason> ReEnterReasons { get; set; }
       public DbSet<ResignReason> ResignReasons { get; set; }
       public DbSet<RetireReason> RetireReasons { get; set; }
       #endregion

       #region University
       public DbSet<Campus> Campuses { get; set; }
       public DbSet<Building> Buildings { get; set; }
       public DbSet<Room> Rooms { get; set; }
       public DbSet<RoomType> RoomTypes { get; set; }
       public DbSet<Faculty> Faculties { get; set; }
       public DbSet<Department> Departments { get; set; }
       public DbSet<Concentration> Concentrations { get; set; }
       public DbSet<Minor> Minors { get; set; }
       #endregion
       
       #region Announcement
       public DbSet<Topic> Topics { get; set; }
       public DbSet<Channel> Channels { get; set; }
       public DbSet<Announcement> Announcements { get; set; }
       public DbSet<AnnouncementTopic> AnnouncementTopics { get; set; }
       #endregion

       #region Address
       public DbSet<Country> Countries { get; set; }
       public DbSet<Province> Provinces { get; set; }
       public DbSet<District> Districts { get; set; }
       public DbSet<Subdistrict> Subdistricts { get; set; }
       public DbSet<City> Cities { get; set; }
       public DbSet<State> States { get; set; }
       #endregion

       #region  Student Model
       public DbSet<Student> Students { get; set; }
       public DbSet<AcademicInformation> AcademicInformations { get; set; }
       public DbSet<AdmissionInformation> AdmissionInformations { get; set; }
       public DbSet<CheatingStatus> CheatingStatuses { get; set; }
       public DbSet<GraduationInformation> GraduationInformations { get; set; }
       public DbSet<MaintenanceStatus> MaintenanceStatuses { get; set; }
       public DbSet<ParentInformation> ParentInformations { get; set; }
       public DbSet<StudentAddress> StudentAddresses { get; set; }
       public DbSet<StudentIncident> StudentIncidents { get; set; }
       #endregion

       #region Withdrawal
       public DbSet<Withdrawal> Withdrawals { get; set; }
       public DbSet<WithdrawalException> WithdrawalExceptions { get; set; }
       public DbSet<WithdrawalPeriod> WithdrawalPeriods { get; set; }
       #endregion

       protected override void OnModelCreating(ModelBuilder builder)
       {      
           base.OnModelCreating(builder);
           // Customize the ASP.NET Identity model and override the defaults if needed.
           // For example, you can rename the ASP.NET Identity table names and more.
           // Add your customizations after calling base.OnModelCreating(builder);
           builder.Entity<IdentityUser>(entity =>
           {
               entity.ToTable(name: "Users");
           });

           builder.Entity<IdentityRole>(entity =>
           {
               entity.ToTable(name: "Roles");
           });

           builder.Entity<IdentityUserRole<string>>(entity =>
           {
               entity.ToTable(name: "UserRoles");
               entity.HasKey(x => new { x.RoleId, x.UserId });
           });

           builder.Entity<IdentityUserClaim<string>>(entity =>
           {
               entity.ToTable(name: "UserClaims");
           });

           builder.Entity<IdentityUserLogin<string>>(entity =>
           {
               entity.ToTable(name: "UserLogins");
               entity.HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });
           });

           builder.Entity<IdentityRoleClaim<string>>(entity =>
           {
               entity.ToTable("RoleClaims");
               entity.HasKey(x => new { x.RoleId, x.Id, x.ClaimType, x.ClaimValue });
           });

           builder.Entity<IdentityUserToken<string>>(entity =>
           {
               entity.ToTable("UserTokens");
               entity.HasKey(x => new { x.LoginProvider, x.UserId, x.Name, x.Value });
           });

           // Primary Key
           builder.Entity<AnnouncementTopic>()
                  .HasKey(x => new { x.AnnouncementId, x.TopicId });

           builder.Entity<CurriculumInstructor>()
                  .HasKey(x => new { x.CurriculumVersionId, x.InstructorId });

       //     #region Schema master
           
           #region Admission
           builder.Entity<AdmissionType>()
                  .ToTable("AdmissionTypes", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<CardExpirationOption>()
                  .ToTable("CardExpirationOptions", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<EducationBackground>()
                  .ToTable("EducationBackgrounds", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<PreviousSchool>()
                  .ToTable("PreviousSchools", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();
           #endregion
           
           #region Academic
           builder.Entity<AcademicHonor>()
                  .ToTable("AcademicHonors", schema: "master")
                  .HasQueryFilter(x => x.IsActive);
           
           builder.Entity<AcademicLevel>()
                  .ToTable("AcademicLevels", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<AcademicProgram>()
                  .ToTable("AcademicPrograms", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<StudentGroup>()
                  .ToTable("StudentGroups", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<RegistrationStatus>()
                  .ToTable("RegistrationStatuses", schema: "master")
                  .HasQueryFilter(x => x.IsActive);
           #endregion

           #region Academic Calendar
           builder.Entity<Event>()
                  .ToTable("Events", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<EventCategory>()
                  .ToTable("EventCategories", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<AcademicCalendar>()
                  .HasQueryFilter(x => x.IsActive);
           #endregion

           #region Course & Section
           builder.Entity<Course>()
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(x => x.Code).IsUnique();

           builder.Entity<Section>()
                  .HasQueryFilter(x => x.IsActive); 

       //     //Course has many section
           builder.Entity<Section>()
                  .HasOne(x => x.Course)
                  .WithMany(x => x.Sections)
                  .OnDelete(DeleteBehavior.Cascade);

           builder.Entity<SectionDetail>()
                  .HasQueryFilter(x => x.IsActive);

           //Section has many section detail
           builder.Entity<SectionDetail>()
                  .HasOne(x => x.Section)
                  .WithMany(x => x.SectionDetails)
                  .OnDelete(DeleteBehavior.Cascade);

           builder.Entity<InstructorSection>()
                  .HasQueryFilter(x => x.IsActive);

           //Section detail may has many instructor
           builder.Entity<InstructorSection>()
                  .HasOne(x => x.SectionDetail)
                  .WithMany(x => x.InstructorSections)
                  .OnDelete(DeleteBehavior.Cascade);
           #endregion

           #region Curriculum
           builder.Entity<Curriculum>()
                  .ToTable("Curriculums", schema: "curriculum")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.ReferenceCode).IsUnique();

           builder.Entity<CurriculumVersion>()
                  .ToTable("CurriculumVersions", schema: "curriculum")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<CurriculumVersion>()
                  .HasOne(x => x.Curriculum)
                  .WithMany(x => x.CurriculumVersions)
                  .OnDelete(DeleteBehavior.Cascade);

           builder.Entity<CurriculumInstructor>()
                  .ToTable("CurriculumInstructors", schema: "curriculum")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<CurriculumInstructor>()
                  .HasOne(x => x.CurriculumVersion)
                  .WithMany(x => x.CurriculumInstructors)
                  .OnDelete(DeleteBehavior.Cascade);

           builder.Entity<CourseGroup>()
                  .ToTable("CourseGroups", schema: "curriculum")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<CourseGroup>()
                  .HasOne(x => x.CurriculumVersion)
                  .WithMany(x => x.CourseGroups)
                  .OnDelete(DeleteBehavior.Cascade);

           builder.Entity<CurriculumCourse>()
                  .ToTable("CurriculumCourses", schema: "curriculum")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<CurriculumCourse>()
                  .HasOne(x => x.CourseGroup)
                  .WithMany(x => x.CurriculumCourses)
                  .OnDelete(DeleteBehavior.Cascade);

           builder.Entity<StudyPlan>()
                  .ToTable("StudyPlans", schema: "curriculum")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<StudyPlan>()
                  .HasOne(x => x.CurriculumVersion)
                  .WithMany(x => x.StudyPlans)
                  .OnDelete(DeleteBehavior.Cascade);

           builder.Entity<Models.DataModels.Curriculums.StudyCourse>()
                  .ToTable("StudyCourses", schema: "curriculum");

           builder.Entity<Models.DataModels.Curriculums.StudyCourse>()
                  .HasOne(x => x.StudyPlan)
                  .WithMany(x => x.StudyCourses)
                  .OnDelete(DeleteBehavior.Cascade);
           #endregion

           #region PersonInfo
           builder.Entity<Title>()
                  .ToTable("Titles", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<Nationality>()
                  .ToTable("Nationalities", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<Race>()
                  .ToTable("Races", schema: "master")
                  .HasQueryFilter(x => x.IsActive);
           
           builder.Entity<Religion>()
                  .ToTable("Religions", schema: "master")
                  .HasQueryFilter(x => x.IsActive);
           #endregion

           #region Examination
           builder.Entity<ExaminationType>()
                  .ToTable("ExaminationTypes", schema: "master")
                  .HasQueryFilter(x => x.IsActive);
           builder.Entity<ExaminationSlot>()
                  .ToTable("ExaminationSlot", schema:"master")
                  .HasQueryFilter(x => x.IsActive);
           builder.Entity<ExaminationRoom>()
                  .ToTable("ExaminationRoom", schema:"master")
                  .HasQueryFilter(x => x.IsActive);
           builder.Entity<CourseExaminationSlot>()
                  .ToTable("CourseExaminationSlot", schema:"master")
                  .HasQueryFilter(x => x.IsActive);
           builder.Entity<ExaminationAssigningLog>()
                  .ToTable("ExaminationAssigningLog", schema: "examination");
           #endregion

           #region Instructor
           builder.Entity<Instructor>()
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           //one to one relationship with cascade delete
           builder.Entity<Instructor>()
                  .HasOne(x => x.InstructorWorkStatus)
                  .WithOne(x => x.Instructor)
                  .OnDelete(DeleteBehavior.Cascade);
           #endregion

           #region Teaching Load
           builder.Entity<TeachingType>()
                  .ToTable("TeachingTypes", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();
           #endregion

           #region Reason
           builder.Entity<ReEnterReason>()
                  .ToTable("ReEnterReasons", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<ResignReason>()
                  .ToTable("ResignReasons", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<RetireReason>()
                  .ToTable("RetireReasons", schema: "master")
                  .HasQueryFilter(x => x.IsActive);
           #endregion

           #region Registration
           builder.Entity<CreditLoad>()
                  .ToTable("CreditLoads", schema: "registration")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<RegistrationSlot>()
                  .ToTable("RegistrationSlots", schema: "registration")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<Slot>()
                  .ToTable("Slots", schema: "registration")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<RegistrationResult>()
                  .ToTable("RegistrationResults", schema: "registration")
                  .HasQueryFilter(x => x.IsActive);
           #endregion

           #region University
           builder.Entity<Campus>()
                  .ToTable("Campuses", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<Building>()
                  .ToTable("Buildings", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<Room>()
                  .ToTable("Rooms", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<RoomType>()
                  .ToTable("RoomTypes", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<Faculty>()
                  .ToTable("Faculties", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<Department>()
                  .ToTable("Departments", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<Concentration>()
                  .ToTable("Concentrations", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<Minor>()
                  .ToTable("Minors", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();
           #endregion

           #region Announcement
           builder.Entity<Channel>()
                  .ToTable("Channels", schema: "announcement")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<Topic>()
                  .ToTable("Topics", schema: "announcement")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<Announcement>()
                  .ToTable("Announcements", schema: "announcement")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<AnnouncementTopic>()
                  .ToTable("AnnouncementTopic", schema: "announcement");
           #endregion

           #region Address
           builder.Entity<Country>()
                  .ToTable("Countries", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<Province>()
                  .ToTable("Provinces", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();
           
           builder.Entity<District>()
                  .ToTable("Districts", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();
           
           builder.Entity<Subdistrict>()
                  .ToTable("Subdistricts", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<City>()
                  .ToTable("Cities", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<State>()
                  .ToTable("States", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();
           #endregion

           #region misc
           builder.Entity<BankBranch>()
                  .ToTable("BankBranches", schema: "master")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<Relationship>()
                  .ToTable("Relationships", schema: "master")
                  .HasQueryFilter(x => x.IsActive);
           
           builder.Entity<Scholarship>()
                  .ToTable("Scholarships", schema: "master")
                  .HasQueryFilter(x => x.IsActive);
           
           builder.Entity<Semester>()
                  .ToTable("Semesters", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<MaintenanceFee>()
                  .ToTable("MaintenanceFees", schema: "master")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<Incident>()
                  .ToTable("Incidents", schema: "master")
                  .HasQueryFilter(x => x.IsActive);
           #endregion

           #region Schema Student
           builder.Entity<Student>()
                  .ToTable("Students", schema: "student")
                  .HasQueryFilter(x => x.IsActive)
                  .HasIndex(p => p.Code).IsUnique();

           builder.Entity<AcademicInformation>()
                  .ToTable("AcademicInformations", schema: "student")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<AdmissionInformation>()
                  .ToTable("AdmissionInformations", schema: "student")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<CheatingStatus>()
                  .ToTable("CheatingStatuses", schema: "student")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<StudentAddress>()
                  .ToTable("StudentAddresses", schema: "student")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<GraduationInformation>()
                  .ToTable("GraduationInformations", schema: "student")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<MaintenanceStatus>()
                  .ToTable("MaintenanceStatuses", schema: "student")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<ParentInformation>()
                  .ToTable("ParentInformations", schema: "student")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<StudentIncident>()
                  .ToTable("StudentIncidents", schema: "student")
                  .HasQueryFilter(x => x.IsActive);
           #endregion

           #region Withdrawal
           builder.Entity<Withdrawal>() 
                  .ToTable("Withdrawals", schema: "withdrawal")
                  .HasQueryFilter(x => x.IsActive);

           builder.Entity<WithdrawalException>()
                  .ToTable("WithdrawalExceptions", schema: "withdrawal")
                  .HasQueryFilter(x => x.IsActive);
       
           builder.Entity<WithdrawalPeriod>()
                  .ToTable("WithdrawalPeriods", schema: "withdrawal")
                  .HasQueryFilter(x => x.IsActive);
           #endregion

           // One to Many
           builder.Entity<AnnouncementTopic>()
                  .HasOne(x => x.Announcement)
                  .WithMany(x => x.AnnouncementTopics)
                  .OnDelete(DeleteBehavior.Cascade);

           //Global Query Filters\
       }

       public override int SaveChanges()
       {
           AddTimestamps();
           return base.SaveChanges();
       }

       public async Task<int> SaveChangesAsync()
       {
           AddTimestamps();
           return await base.SaveChangesAsync();
       }

       public int SaveChanges(string by) 
       {
              AddTimestamps(by);
              return base.SaveChanges();
       }

       private void AddTimestamps(string by = "User")
       {
           var changedEntities = ChangeTracker.Entries();
           foreach (var changedEntity in changedEntities)
           {
               if (changedEntity.Entity is Entity)
               {
                   var entity = (Entity)changedEntity.Entity;
                   switch (changedEntity.State)
                   {
                       case EntityState.Added:
                            entity.OnBeforeInsert(by);
                            break;

                       case EntityState.Modified:
                            entity.OnBeforeUpdate(by);
                            break;
                   }
               }
           }
       }
    }
}