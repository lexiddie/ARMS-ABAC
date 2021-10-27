using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class AdmissionInformation : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long? PreviousSchoolId { get; set; }
        public long? EducationBackgroundId { get; set; }
        public int? PreviousGraduatedYear { get; set; }
        public decimal? PreviousSchoolGPA { get; set; }

        [Required]
        public long AdmissionTypeId { get; set; }

        [Required]
        public long AdmissionSemesterId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime AdmissionDate { get; set; }

        [DataType(DataType.Date)] 

        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]  
        public DateTime CheckDated { get; set; } // Confirmation from pre-school date 

        [StringLength(200)] 
        public string CheckReferenceNumber { get; set; } 

        [DataType(DataType.Date)] 

        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)] 
        public DateTime ReplyDate { get; set; } 

        [StringLength(200)] 
        public string ReplyReferenceNumber { get; set; }

        [JsonIgnore]
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("PreviousSchoolId")]
        public virtual PreviousSchool PreviousSchool { get; set; }

        [ForeignKey("EducationBackgroundId")]
        public virtual EducationBackground EducationBackground { get; set; }

        [ForeignKey("AdmissionTypeId")]
        public virtual AdmissionType AdmissionType { get; set; }

        [ForeignKey("AdmissionSemesterId")]
        public virtual Semester Semester { get; set; }

        [NotMapped]
        public long? SchoolCountryId 
        { 
            get 
            { 
                return PreviousSchool?.CountryId; 
            }
        }
    }
}
