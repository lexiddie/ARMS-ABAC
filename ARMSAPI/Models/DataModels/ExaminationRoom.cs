using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class ExaminationRoom : UserTimeStamp
    {
        public long Id { get; set; }
        public long SectionId { get; set; }
        public long CourseId {get; set;}
        public long ExaminationSlotId {get; set;}
        public long RoomId { get; set; }
        public string StartStudentCode {get; set;}
        public string EndStudentCode {get; set;}
        public int TotalSeatUsed {get; set;}
        public bool IsAuto { get; set; }
    

        [JsonIgnore]
        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        [JsonIgnore]
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [JsonIgnore]
        [ForeignKey("ExaminationSlotId")]
        public virtual ExaminationSlot ExaminationSlot {get; set;}

        [JsonIgnore]
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

       
       
    }
}