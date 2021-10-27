using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class InstructorSection : UserTimeStamp
    {
        public long Id { get; set; }
        public long SectionDetailId { get; set; }
        public long InstructorId { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public decimal Hours { get; set; }
        
        [JsonIgnore]
        [ForeignKey("SectionDetailId")]
        public virtual SectionDetail SectionDetail { get; set; }

        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; }
    }
}