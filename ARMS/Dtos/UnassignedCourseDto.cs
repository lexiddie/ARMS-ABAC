namespace ARMS.Dtos
{
    public class UnassignedCourseDto
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }

        public int TotalSection { get; set; }

        public int TotalStudent { get; set; }

        public ExaminationSlotDto ExaminationSlot { get; set; }

        public string CodeAndName => $"{ Code } { Name }";
    }
}