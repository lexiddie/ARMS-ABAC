namespace ARMSAPI.Models
{
    public class DissolveCourseViewModel
    {
        public long CourseId { get; set; }
        public long ExaminationSlotId { get; set; }
        public long SemesterId { get; set; }
        public long ExaminationTypeId { get; set; }
        public int Code { get; set; }
        public string User { get; set; }
    }
}