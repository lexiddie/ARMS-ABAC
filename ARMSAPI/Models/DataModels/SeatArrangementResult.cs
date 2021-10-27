using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class SeatArrangementResult : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentId {get; set;}
        public long SectionId {get; set;} 
        public long CourseId {get; set;}
        public long ExaminationSlotId {get; set;}
        public long RoomId {get; set;}
        public int SeatNumber {get; set;}
        public int RowNumber {get; set;}
        public bool IsAuto { get; set; }

        [JsonIgnore]
        [ForeignKey("StudentId")]
        public virtual Student Student {get; set; }

        [JsonIgnore]
        [ForeignKey("SectionId")]
        public virtual Section Section {get; set; }

        [JsonIgnore]
        [ForeignKey("CourseId")]
        public virtual Course Course {get; set; }

        [JsonIgnore]
        [ForeignKey("RoomId")]
        public virtual Room Room {get; set; }
        
        [JsonIgnore]
        [ForeignKey("ExaminationSlotId")]
        public virtual ExaminationSlot ExaminationSlot {get; set;}

        [NotMapped]
        public string RowSeat
        {
            get
            {
               return $"{ RowNumber }{'/'}{ SeatNumber }";
            }
        }
        
    }
}