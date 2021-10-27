using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;

namespace ARMSAPI.Models.DataModels
{
    public class Instructor : UserTimeStamp
    {
        public long Id { get; set; }
        public long TitleId { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(100)]
        public string FirstNameEn { get; set; }

        [StringLength(100)]
        public string FirstNameTh { get; set; }

        [StringLength(100)]
        public string LastNameEn { get; set; }

        [StringLength(100)]
        public string LastNameTh { get; set; }
        public int Gender { get; set; } // 0 = undefined, 1 = male, 2 = female
        public long NationalityId { get; set; }
        public long RaceId { get; set; }
        public long ReligionId { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
        public long CountryId { get; set; }
        public long? CityId { get; set; }
        public long? StateId { get; set; }
        public long? ProvinceId { get; set; }
        public long? DistrictId { get; set; }
        public long? SubdistrictId { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }
        
        [StringLength(20)]
        public string TelephoneNumber1 { get; set; }

        [StringLength(20)]
        public string TelephoneNumber2 { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string PersonalEmail { get; set; }

        [StringLength(2100)]
        public string ProfileImageURL { get; set; }

        [ForeignKey("TitleId")]
        public virtual Title Title { get; set; }

        [ForeignKey("NationalityId")]
        public virtual Nationality Nationality { get; set; }

        [ForeignKey("RaceId")]
        public virtual Race Race { get; set; }

        [ForeignKey("ReligionId")]
        public virtual Religion Religion { get; set; }
        
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        [ForeignKey("SubdistrictId")]
        public virtual Subdistrict Subdistrict { get; set; }

        public virtual InstructorWorkStatus InstructorWorkStatus { get; set; }

        [NotMapped]
        public string FullNameEn { get { return $"{ FirstNameEn } { LastNameEn }"; } }

        [NotMapped]
        public string FullNameTh { get { return $"{ FirstNameTh } { LastNameTh}"; } }

        [NotMapped]
        public string GenderText 
        { 
            get 
            { 
                if (Gender == 1)
                {
                    return "Male";
                }
                else if (Gender == 2)
                {
                    return "Female";
                }
                else
                {
                    return "Not Specify";
                }
            } 
        }

        [NotMapped]
        public string CodeAndName 
        { 
            get 
            { 
                return $"{ Code } { FirstNameEn } { LastNameEn?.Substring(0,1) }."; 
            } 
        }
    }
}