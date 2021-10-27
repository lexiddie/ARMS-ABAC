namespace ARMS.ViewModels
{
    public class CourseSearchViewModel
    {
        public long SemesterId { get; set; }

        public long ExaminationTypeId { get; set; }

        public long CourseId { get; set; }

        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }
        
        public string SessionText { get; set; }

        public string Courses { get; set; }
    }
}