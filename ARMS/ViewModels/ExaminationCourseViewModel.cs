namespace ARMS.ViewModels
{
    public class ExaminationCourseViewModel
    {
        public long SemesterId { get; set; }

        public long CourseId { get; set; }
        
        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }
        
        public string CourseCodeName { get; set; }

        public long SectionId { get; set; }

        public string SectionNumber { get; set; }


        public string ExaminationCourses { get; set; }

        public string Sections { get; set; }
        
        public string Students { get; set; }
    }
}