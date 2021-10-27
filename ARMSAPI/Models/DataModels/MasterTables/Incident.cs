using System;
using System.ComponentModel.DataAnnotations;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class Incident : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }
        public bool LockedDocument { get; set; }
        public bool LockedRegistration { get; set; }
        public bool LockedPayment { get; set; }
        public bool LockedVisa { get; set; }
        public bool LockedGraduation { get; set; }
        public bool LockedChangeFaculty { get; set; }
    }
}