using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class Campus : UserTimeStamp
    {
        public long Id { get; set; }
	
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }
        
        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }

        [StringLength(500)]
        public string Address1En { get; set; }

        [StringLength(500)]
        public string Address2En { get; set; }

        [StringLength(500)]
        public string Address1Th { get; set; }
        
        [StringLength(500)]
        public string Address2Th { get; set; }
        public long CountryId { get; set; }
        public long ProvinceId { get; set;}
        public long DistrictId { get; set; }
        public long SubdistrictId { get; set; }

        [Required]
        [StringLength(10)]
        public string Zipcode { get; set; }

        [Required]
        [StringLength(20)]
        public string TelephoneNumber1 { get; set; }

        [StringLength(20)]
        public string TelephoneNumber2 { get; set; }
        
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set;}

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set;}

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        [ForeignKey("SubdistrictId")]
        public virtual Subdistrict Subdistrict { get; set; }
        public virtual List<Building> Buildings { get; set; }

        [NotMapped]
        public string TelephoneNumber 
        {
            get
            {
                return $"{ TelephoneNumber1 }, { TelephoneNumber2 }"; 
            } 
        }
    }
}