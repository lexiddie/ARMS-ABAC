using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class StudyCourse : UserTimeStamp 
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long SemesterId { get; set; }
        public long CourseId { get; set; }
        public long SectionId { get; set; }
        public bool IsPaid { get; set; }

        [StringLength(5)]
        public string Grade { get; set; }

        [StringLength(5)]
        public string EstimatedGrade { get; set; }
        public bool IsSurveyed { get; set; }

        
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [JsonIgnore]
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
        [JsonIgnore]
        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}