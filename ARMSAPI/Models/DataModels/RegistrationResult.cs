using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class RegistrationResult : UserTimeStamp
    {
        public long Id { get; set; }

        [StringLength(5)]
        public string Channel { get; set; } // R = Officer, I = Ios, A = Android, W = Web
        public long StudentId { get; set; }
        public long SemesterId { get; set; }
        public long CourseId { get; set; }
        public long SectionId { get; set; }
        public bool IsLock { get; set; }
        public bool IsPaid { get; set; }
        
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }
    }
}