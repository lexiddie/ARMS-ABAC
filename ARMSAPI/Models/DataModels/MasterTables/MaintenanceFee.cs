using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class MaintenanceFee : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentGroupId { get; set; }
        public long SemesterId { get; set; }
        public long AcademicLevelId { get; set; }
        public long? FacultyId { get; set; }
        public long? DepartmentId { get; set; }

        [Required]
        public decimal Fee { get; set; }

        [ForeignKey("StudentGroupId")]
        public virtual StudentGroup StudentGroup { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        [ForeignKey("AcademicLevelId")]
        public virtual AcademicLevel AcademicLevel { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}