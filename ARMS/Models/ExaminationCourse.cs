namespace ARMS.Models
{
    public class ExaminationCourse
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }

        public int TotalSection { get; set; }

        public int TotalStudent { get; set; }

        public virtual ExaminationSlot Midterm { get; set; }

        public virtual ExaminationSlot Final { get; set; }

        public string CodeAndName => $"{ Code } { Name }";
    }
}