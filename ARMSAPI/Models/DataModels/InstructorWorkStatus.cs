using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class InstructorWorkStatus : UserTimeStamp
    {
        public long Id { get; set; }
        public long InstructorId { get; set; }

        [StringLength(2)]
        public string Type { get; set; } // p = Part_time, f = full_time etc.

        [StringLength(100)]
        public string AdminPosition { get; set; }

        [StringLength(100)]
        public string AcademicPosition { get; set; }

        [StringLength(100)]
        public string Metier { get; set; }

        [StringLength(100)]
        public string Division { get; set; }

        [StringLength(100)]
        public string Job { get; set; }
        public long? AcademicLevelId { get; set; }
        public long? FacultyId { get; set; }
        public long? DepartmentId { get; set; }
        
        [StringLength(100)]
        public string OfficeRoom { get; set; }
        public decimal TeachingHour { get; set; }
        public decimal GraduatedLoad { get; set; }
        public decimal UnderGraduateLoad { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        [JsonIgnore]
        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; }
        
        [ForeignKey("AcademicLevelId")]
        public virtual AcademicLevel AcademicLevel { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [NotMapped]
        public string TypeText 
        { 
            get 
            { 
                if (Type == "p")
                {
                    return "Part-Time";
                }
                else if (Type == "f")
                {
                    return "Full-Time";
                }
                else
                {
                    return "Not Specify";
                }
            } 
        }

    }
}