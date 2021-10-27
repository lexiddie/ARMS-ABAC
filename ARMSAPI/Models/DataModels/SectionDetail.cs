using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class SectionDetail : UserTimeStamp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long SectionId { get; set; }
        public long TeachingTypeId { get; set; }
        public long? RoomId { get; set; }
        public long? CampusId {get; set;}
        public int Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        [StringLength(100)]
        public string InstructorIds { get; set; }
        
        [JsonIgnore]
        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        [JsonIgnore]
        public virtual List<InstructorSection> InstructorSections { get; set; }

        [JsonIgnore]
        [ForeignKey("TeachingTypeId")]
        public virtual TeachingType TeachingType { get; set; }
        
        [JsonIgnore]
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        
        [JsonIgnore]
        [ForeignKey("CampusId")]
        public virtual Campus Campus { get; set; }

        [NotMapped]
        public string Time 
        { 
            get 
            { 
                return $"{ StartTime } - { EndTime }"; 
            } 
        }
        
        [NotMapped]
        public String Dayofweek
        {
            get
            {
               var day = Enum.GetName(typeof(DayOfWeek),Day);
               return day ;
            }
        }
    }
}