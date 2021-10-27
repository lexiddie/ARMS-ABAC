namespace ARMS.Dtos
{
    public class SeatingStudentDto
    {
        public long Id { get; set; }

        public string CourseCode { get; set; }
        
        public long SectionId { get; set; }

        public int Row { get; set; }
        
        public int Seat { get; set; }
    }
}