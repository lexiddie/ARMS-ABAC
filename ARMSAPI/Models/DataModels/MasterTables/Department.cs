using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class Department : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(500)]
        public string NameTh { get; set; }

        [Required]
        [StringLength(500)]
        public string NameEn { get; set; }

        [StringLength(200)]
        public string ShortNameTh { get; set; }

        [StringLength(200)]
        public string ShortNameEn { get; set; }

        [StringLength(50)]
        public string Abbreviation { get; set; }

        [StringLength(2100)]
        public string LogoURL { get; set; }
        public long FacultyId { get; set; }

        [JsonIgnore]
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }

        [NotMapped]
        public string CodeAndName
        { 
            get 
            {
                return $"{ Code } - { NameEn }"; 
            }
        }
    }
}