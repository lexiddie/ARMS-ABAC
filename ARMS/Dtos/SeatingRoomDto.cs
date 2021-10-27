namespace ARMS.Dtos
{
    public class SeatingRoomDto
    {
        public long RoomId { get; set; }

        public long ExaminationSlotId { get; set; }

        public int ExaminationStudents { get; set; }
        // public List<SeatingStudentDto> ExaminationStudents { get; set; }
    }
}