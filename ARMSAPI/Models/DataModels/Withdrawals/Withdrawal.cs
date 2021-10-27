using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.Withdrawals
{
    public class Withdrawal : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudyCourseId { get; set; }

        [Required]
        [StringLength(1)]
        public string Type { get; set; } // p = petition, u = uspark, d = debarment, a = admin
        public DateTime RequestedAt { get; set; }
        public string Remark { get; set; }
        
        // Request by
        public long? InstructorId { get; set; }
        public long? StudentId { get; set; }
        public long? UserId { get; set; }
        
        [ForeignKey("StudyCourseId")]
        public virtual StudyCourse StudyCourse { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}