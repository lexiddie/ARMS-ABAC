using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using ARMSAPI.Models.DataModels.Curriculums;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class AcademicInformation : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentId { get; set; }

        [StringLength(20)]
        public string OldStudentCode { get; set; }

        [StringLength(20)]
        public string Batch { get; set; }

        [Required]
        public long StudentGroupId { get; set; }

        [Required]
        public decimal GPA { get; set; }

        [Required]
        public int CreditComp { get; set; } // not count F
        public int? CreditExempted { get; set; } // Transfer credits form ACC
        public int? CreditEarned { get; set; } // total credit, accumulated credit
        public int? CreditLimit { get; set; }
        public int? CreditTransfer { get; set; } // grade TR, CS, CP, PR, CE, CT
        public long? CurriculumVersionId { get; set; }
        public long AcademicProgramId { get; set; } // Day, Night, Fast track
        public long AcademicLevelId { get; set; } // Bachelor, Master, Doctor
        
        [StringLength(200)]
        public string DegreeName { get; set; }
        public long FacultyId { get; set; }
        public long? DepartmentId { get; set; }
        public long? MinorId { get; set; }
        public long? SecondMinorId { get; set; }
        public long? ConcentrationId { get; set; }
        public long? SecondConcentrationId { get; set; }
        public long? ScholarshipId { get; set; }
        public bool IsAthlete { get; set; }

        [JsonIgnore]
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("StudentGroupId")]
        public virtual StudentGroup StudentGroup { get; set; }

        [ForeignKey("CurriculumVersionId")]
        public virtual CurriculumVersion CurriculumVersion { get; set; }

        [ForeignKey("AcademicProgramId")]
        public virtual AcademicProgram AcademicProgram { get; set; }

        [ForeignKey("AcademicLevelId")]
        public virtual AcademicLevel AcademicLevel { get; set; }

        [JsonIgnore]
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }

        [JsonIgnore]
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [JsonIgnore]
        [ForeignKey("MinorId")]
        public virtual Minor Minor { get; set; }

        [JsonIgnore]
        [ForeignKey("ConcentrationId")]
        public virtual Concentration Concentration { get; set; }
        
        [JsonIgnore]
        [ForeignKey("SecondMinorId")]
        public virtual Minor SecondMinor { get; set; }

        [JsonIgnore]
        [ForeignKey("SecondConcentrationId")]
        public virtual Concentration SecondConcentration { get; set; }

        [ForeignKey("ScholarshipId")]
        public virtual Scholarship Scholarship { get; set; }
    }
}