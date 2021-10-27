using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class Course : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        public long AcademicLevelId { get; set; }
        public long FacultyId { get; set; }
        public long DepartmentId { get; set; }

        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }

        [Required]
        [StringLength(80)]
        public string ShortNameEn { get; set; }

        [Required]
        [StringLength(80)]
        public string ShortNameTh { get; set; }

        [StringLength(500)]
        public string DescriptionEn { get; set; }

        [StringLength(500)]
        public string DescriptionTh { get; set; }

        [Required]
        public decimal Credit { get; set; }
        
        [Required]
        public decimal RegistrationCredit { get; set; }

        [Required]
        public decimal PaymentCredit { get; set; }
        public long TeachingTypeId { get; set; }
        public decimal Hour { get; set; }

        //show in curriculum
        public decimal Lecture { get; set; }
        public decimal Lab { get; set; }
        public decimal Other { get; set; } // Self study
        public bool WillShowTranscript { get; set; }
        public bool WillCalculateCredit { get; set; } // Calculate accumulated credit
        public bool IsIntensiveCourse { get; set; }
        public bool IsSectionGroup { get; set; } // Big lecture room with many sections
        public int MinimumSeat { get; set; } // If section's seat used less than minimum seat, Officer will close this section.

        [NotMapped]
        public string CreditText 
        { 
            get 
            { 
                return Credit.ToString("G29"); 
            } 
        }

        [NotMapped]
        public string CodeAndName
        { 
            get 
            {
                return $"{ Code } { NameEn }"; 
            }
        }

        [JsonIgnore]
        [ForeignKey("AcademicLevelId")]
        public virtual AcademicLevel AcademicLevel { get; set; }

        [JsonIgnore]
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }

        [JsonIgnore]
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [JsonIgnore]
        [ForeignKey("TeachingTypeId")]
        public virtual TeachingType TeachingType { get; set; }

        [JsonIgnore]        
        public virtual List<Section> Sections { get; set; }

        [JsonIgnore]
        public virtual List<ExaminationRoom> ExaminationRoom {get; set; }

        [JsonIgnore]
        public virtual ICollection<CourseExaminationSlot> CourseExaminationSlots {get; set;}
        [JsonIgnore]
        public virtual ICollection<StudyCourse> StudentStudyCourses {get; set;}
    }
}