namespace ARMS.Dtos
{
    public class ExaminationStudentDto
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SectionNumber { get; set; }

        public int SeatNumber { get; set; }

        public int RowNumber { get; set; }

        public string CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}