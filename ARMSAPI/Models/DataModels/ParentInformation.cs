using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class ParentInformation : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public long RelationshipId { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        public bool MailToParent { get; set; }
        public bool EmailToParent { get; set; }
        public bool SMSToParent { get; set; }

        [Required]
        [StringLength(20)]
        public string TelephoneNumber1 { get; set; }

        [StringLength(20)]
        public string TelephoneNumber2 { get; set; }

        [StringLength(500)]
        public string AddressTh { get; set; }

        [StringLength(500)]
        public string AddressEn { get; set; }
        public long? CountryId { get; set; }
        public long? ProvinceId { get; set; }
        public long? DistrictId { get; set; }
        public long? SubdistrictId { get; set; }
        public long? CityId { get; set; }
        public long? StateId { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        [JsonIgnore]
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        [ForeignKey("SubdistrictId")]
        public virtual Subdistrict Subdistrict { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        [ForeignKey("RelationshipId")]
        public virtual Relationship Relationship { get; set; }

        [NotMapped]
        public string TelephoneText 
        { 
            get 
            { 
                return String.IsNullOrEmpty(TelephoneNumber2) ? TelephoneNumber1 : $"{ TelephoneNumber1}, { TelephoneNumber2 }";
            } 
        }
    }
}