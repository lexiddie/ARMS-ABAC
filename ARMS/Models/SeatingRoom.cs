using System.Collections.Generic;

namespace ARMS.Models
{
    public class SeatingRoom
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public long CampusId { get; set; }

        public string CampusName { get; set; }

        public long BuildingId { get; set; }

        public string BuildingName { get; set; }
        
        public long ExaminationSlotId { get; set; }

        public string ExaminationDateTime { get; set; }

        public int TotalStudent { get; set; }

        public List<SeatingStudent> SeatingStudents { get; set; }
    }
}