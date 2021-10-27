using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.Withdrawals
{
    public class WithdrawalException : UserTimeStamp
    {
        public long Id { get; set; }
        public long? FacultyId { get; set; }
        public long? DepartmentId { get; set; }
        public long? CourseId { get; set; }
        public long? StudentId { get; set; }
        
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}