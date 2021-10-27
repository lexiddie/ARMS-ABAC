using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.Withdrawals
{
    public class WithdrawalPeriod : UserTimeStamp
    {
        public long Id { get; set; }
        public long AcademicLevelId { get; set; }
        public long SemesterId { get; set; }

        [Required]
        [StringLength(1)]
        public string Type { get; set; } // p = petition, u = uspark, d = debarment, a = admin
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
    }
}