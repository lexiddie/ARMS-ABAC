namespace ARMS.ViewModels
{
    public class ExaminationRoomViewModel
    {
        public long SemesterId { get; set; }

        public long ExaminationTypeId { get; set; }

        public long ExaminationSlotId { get; set; }

        public long CourseId { get; set; }

        public string CourseCodeName { get; set; }

        public string ExaminationRooms { get; set; }
    }
}