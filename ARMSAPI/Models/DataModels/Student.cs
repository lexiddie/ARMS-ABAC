using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class Student : UserTimeStamp
    {
        
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        public long TitleId { get; set; }

        [StringLength(100)]
        public string FirstNameTh { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstNameEn { get; set; }

        [StringLength(100)]
        public string LastNameTh { get; set; }
        
        [Required]
        [StringLength(100)]
        public string LastNameEn { get; set; }

        [Required]
        public int Gender { get; set; } // 0 = undefined, 1 = male, 2 = female
        public long RaceId { get; set; }
        public long NationalityId { get; set; }
        public long ReligionId { get; set; }

        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime? BirthDate { get; set; } = DateTime.Now;
        public long? BirthProvinceId { get; set; } 
        public long? BirthStateId { get; set; }
        public long BirthCountryId { get; set; }

        [StringLength(20)]
        public string CitizenNumber { get; set; }

        [StringLength(20)]
        public string Passport { get; set; }
        public long? BankBranchId { get; set; } 

        [StringLength(20)]
        public string BankAccount { get; set; }

        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime? AccountUpdatedAt { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string PersonalEmail { get; set; }
        
        [StringLength(20)]
        public string TelephoneNumber1 { get; set; }

        [StringLength(20)]
        public string TelephoneNumber2 { get; set; }

        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime? IdCardCreatedDate { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime? IdCardExpiredDate { get; set; } = DateTime.Now;
        public long RegistrationStatusId { get; set; } 
        
        [StringLength(1000)] 
        public string StudentRemark { get; set; } 

        [StringLength(2100)]
        public string ProfileImageURL { get; set; }

        [ForeignKey("TitleId")]
        public virtual Title Title { get; set; }

        [ForeignKey("RaceId")]
        public virtual Race Race { get; set; }

        [ForeignKey("NationalityId")]
        public virtual Nationality Nationality { get; set; }

        [ForeignKey("ReligionId")]
        public virtual Religion Religion { get; set; }

        [ForeignKey("BirthProvinceId")]
        public virtual Province BirthProvince { get; set; }

        [ForeignKey("BirthStateId")]
        public virtual State BirthState { get; set; }

        [ForeignKey("BirthCountryId")]
        public virtual Country BirthCountry { get; set; }

        [ForeignKey("BankBranchId")]
        public virtual BankBranch BankBranch { get; set; }

        [ForeignKey("RegistrationStatusId")]
        public virtual RegistrationStatus RegistrationStatus { get; set; }

        public virtual AcademicInformation AcademicInformation { get; set; }
        public virtual AdmissionInformation AdmissionInformation { get; set; }
        public virtual GraduationInformation GraduationInformation { get; set; }
        public virtual List<ParentInformation> ParentInformations { get; set; }
        public virtual List<StudentAddress> StudentAddresses { get; set; }
        public virtual List<CheatingStatus> CheatingStatuses { get; set; }
        public virtual List<MaintenanceStatus> MaintenanceStatuses { get; set; }
        public virtual List<StudentIncident> StudentIncidents { get; set; }
        [JsonIgnore]
        public virtual List<StudyCourse> StudyCourses { get; set; }

        [NotMapped]
        public string FullNameEn 
        { 
            get 
            { 
                return $"{ FirstNameEn } { LastNameEn }"; 
            } 
        }

        [NotMapped]
        public string FullNameTh 
        { 
            get 
            { 
                return $"{ FirstNameTh } { LastNameTh }"; 
            } 
        }
        
        // Faculty --> Department --> Curriculum
        // A student can get 1 Faculty, 1 Department and 1 Curriculum.
        // If student change faculty or department, curriculum will change too.
        // (Add in OnModelCreate, change curriculum in student, get FacultyId and DepartmentId from curriculumId and change in Student table)
        // Student can get 1-2 minors or 1-2 concentations.
        // Concentation depend on curriculum.
        // Minor is undependence but it should approve from curriculum.
    }
}