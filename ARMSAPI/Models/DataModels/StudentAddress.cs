using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class StudentAddress : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentId { get; set; }

        [StringLength(500)]
        public string AddressEn { get; set; }

        [StringLength(500)]
        public string AddressTh { get; set; }
        public long CountryId { get; set; }
        public long? ProvinceId { get; set; }
        public long? DistrictId { get; set; }
        public long? SubdistrictId { get; set; }
        public long? CityId { get; set; }
        public long? StateId { get; set; }

        [Required]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [StringLength(20)]
        public string TelephoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; } // Permanent, Current

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
    }
}