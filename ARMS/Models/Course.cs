namespace ARMS.Models
{
    public class Course
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }

        public Faculty Faculty { get; set; }

        public Department Department { get; set; }

        public string CodeAndName => $"{ Code } { Name }";

        public string CreatedDate { get; set; }

        public string CreatedTime { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}