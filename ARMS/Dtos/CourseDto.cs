namespace ARMS.Dtos
{
    public class CourseDto
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string NameEn { get; set; }

        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }

        public string CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}