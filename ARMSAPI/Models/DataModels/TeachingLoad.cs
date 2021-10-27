
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class TeachingLoad : UserTimeStamp
    {
        public long Id { get; set; }
        public long SemesterId { get; set; }
        public long InstructorId { get; set; }
        public long CourseId { get; set; }
        public int TotalSectionsCount { get; set; }
        public long TeachingTypeId { get; set; }
        public decimal Load { get; set; }
        public bool IsExtraLoad { get; set; }

        [StringLength(500)]
        public string Remark { get; set; } // for equivalent course
        public bool IsUpdated { get; set; }

        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        [ForeignKey("TeachingTypeId")]
        public virtual TeachingType TeachingType { get; set; }
    }
}