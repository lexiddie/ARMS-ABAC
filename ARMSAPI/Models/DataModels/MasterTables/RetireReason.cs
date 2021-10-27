using System;
using System.ComponentModel.DataAnnotations;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class RetireReason : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(500)]
        public string DescriptionEn { get; set; }
        
        [Required]
        [StringLength(500)]
        public string DescriptionTh { get; set; }
    }
}