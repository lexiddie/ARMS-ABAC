namespace ARMS.Models
{
    public class UnassignedCourse
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }

        public int TotalSection { get; set; }

        public int TotalStudent { get; set; }

        public ExaminationSlot ExaminationSlot { get; set; }

        public string Text => $"{ Code } { Name }";
    }
}