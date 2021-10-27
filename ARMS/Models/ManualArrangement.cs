using System.Collections.Generic;

namespace ARMS.Models
{
    public class ManualArrangement
    {
        public long CourseId { get; set; }

        public long ExaminationSlotId { get; set; }

        public List<long> RoomIds { get; set; }

        public string User { get; set; }
    }
}