using System;
using System.ComponentModel.DataAnnotations;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class AcademicLevel : UserTimeStamp
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
    }
}