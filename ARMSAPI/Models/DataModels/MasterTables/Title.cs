
using System;
using System.ComponentModel.DataAnnotations;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class Title : UserTimeStamp
    {
        public long Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }

        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }
        public int Order { get; set; }

    }
}