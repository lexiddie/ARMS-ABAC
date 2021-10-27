using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class ReEnterReason : UserTimeStamp
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