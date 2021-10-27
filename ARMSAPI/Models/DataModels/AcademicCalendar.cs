using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class AcademicCalendar : UserTimeStamp
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long SemesterId { get; set; }
        public long? AcademicLevelId { get; set; } // Null is for all academic level

        [StringLength(500)]
        public string Remark { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.Now;
        public DateTime EndedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
        
        [JsonIgnore]
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        [JsonIgnore]
        [ForeignKey("AcademicLevelId")]
        public virtual AcademicLevel AcademicLevel { get; set; }

        [NotMapped]
        public long? EventCategoryId 
        { 
            get 
            { 
                return Event?.EventCategoryId; 
            }
        }
    }
}