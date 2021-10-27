namespace ARMSAPI.Models
{
    public class Criteria
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public long FacultyId { get; set; }
        public string FacultyName { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public long AcademicLevelId { get; set; }
        public long NationalityId { get; set; }
        public string NationalityName { get; set; }
        public string Status { get; set; }
        public string Passport { get; set; }
        public string CitizenNumber { get; set; }
        public bool SeatAvailable { get; set; } = true;
        public string Semester { get; set; }
        public long CourseId { get; set; }
        public long SectionId { get; set; }
        public long SemesterId { get; set; }
    }
}