using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class Section : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Number { get; set; }
        public long CourseId { get; set; }
        public long SemesterId { get; set; }
        public int SeatAvailable { get; set; }
        public int SeatLimit { get; set; }
        public int SeatUsed { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public bool IsSpecialCase { get; set; }
        public bool IsClosed { get; set; }
        public bool IsEvening { get; set; }
        public bool IsParent { get; set; }
        public long? ParentSectionId { get; set; } //use for Section Group case
        public virtual List<SectionDetail> SectionDetails { get; set; }
        public virtual List<StudyCourse> StudyCourses { get; set; }
        public virtual List<ExaminationRoom> ExaminationRoom {get; set; }


        [NotMapped]
        public decimal AvailabilityPercentage 
        {
            get 
            { 
                return (SeatLimit <= 0) ? 0 : (SeatAvailable * 100) / SeatLimit;
            }
        }

        [JsonIgnore]
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        
        [ForeignKey("ParentSectionId")]
        public virtual Section ParentSection { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        // [JsonIgnore]
        // [ForeignKey("MidtermRoomId")]
        // public virtual Room MidtermRoom { get; set; }

        // [JsonIgnore]
        // [ForeignKey("FinalRoomId")]
        // public virtual Room FinalRoom { get; set; }

        // [NotMapped]
        // public string Final 
        // { 
        //     get 
        //     { 
        //         return $"{ FinalDate }({ FinalStart } - { FinalEnd }) "; 
        //     } 
        // }

        // [NotMapped]
        // public string Midterm 
        // { 
        //     get 
        //     { 
        //         return $"{ MidtermDate }({ MidtermStart } - { MidtermEnd }) "; 
        //     } 
        // }
    }
}