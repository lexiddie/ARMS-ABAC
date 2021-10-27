using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class City : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        
        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }
        public long CountryId { get; set; }
        
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set;}
    }
}