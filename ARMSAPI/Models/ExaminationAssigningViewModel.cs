using System.Collections.Generic;
using ARMSAPI.Models.DataModels;
namespace ARMSAPI.Models
{
    public class ExaminationAssigningViewModel
    {
        public long CourseId { get; set; }
        public long ExaminationSlotId { get; set; }
        public List<long> RoomIds { get; set; }
        public long SemesterId { get; set; }
        public long ExaminationTypeId { get; set; }
        public string User { get; set; }
    }

    public class ExaminationAssigningResultViewModel
    {
        public List<ExaminationRoom> ExaminationRooms { get; set; }
        public List<SeatArrangementResult> SeatArrangementResults { get; set; }
    }

    public class SectionStudent
    {
        public Section Section { get; set; }
        public List<StudentCodeViewModel> StudentCodes { get; set; }
    }

    public class StudentCodeViewModel
    {
        public long StudentId { get; set; }
        public string StudentCode { get; set; }
    }

    public class SectionSlotViewModel
    {
        public List<SectionStudent> SectionStudents { get; set; }
        public List<SectionStudent> SingleSectionStudents { get; set; }
        public long ExaminationSlotId { get; set; }
        public List<ExaminationAssigningRoomViewModel> Rooms { get; set; }
    }

    public class StudentSectionViewModel
    {
        public long StudentId { get; set; }
        public long SectionId { get; set; }
    }

    public class SeatAssigningViewModel
    {
        public ExaminationAssigningRoomViewModel Room { get; set; }
        public long CourseId { get; set; }
        public List<StudentSectionViewModel> Students { get; set; } = new List<StudentSectionViewModel>();
        public List<SectionStudent> SectionStudents { get; set; } = new List<SectionStudent>();
        public long ExaminationSlotId { get; set; }
    }

    public class CampusRoomViewModel
    {
        public long CampusId { get; set; }
        public List<ExaminationAssigningRoomViewModel> Rooms { get; set; }
        public List<SectionStudent> SectionStudents { get; set; }
    }

    public class ExaminationAssigningRoomViewModel
    {
        public long Id { get; set; }
        public long CampusId { get; set; }
        public int Capacity { get; set; }
        public int Rows { get; set; }
        public int Seats { get; set; }
    }

    public class SectionExaminationSlot
    {
        public long ExaminationSlotId { get; set; }
        public long SectionId { get; set; }
        public virtual Section Section { get; set; }
    }

}