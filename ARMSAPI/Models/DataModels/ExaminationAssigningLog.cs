using System;

namespace ARMSAPI.Models.DataModels
{
    public class ExaminationAssigningLog
    {
        public long Id { get; set; }
        public string LogType { get; set; }
        public string ActivityType { get; set; }
        public long SemesterId { get; set; }
        public long ExaminationTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}