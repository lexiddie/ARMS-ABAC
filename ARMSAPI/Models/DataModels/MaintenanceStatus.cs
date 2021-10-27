using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;

namespace ARMSAPI.Models.DataModels
{
    public class MaintenanceStatus : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long SemesterId { get; set; }
        public long MaintenanceFeeId { get; set; }
        public DateTime? PaidDate { get; set; }

        [StringLength(200)]
        public string InvoiceNumber { get; set; }

        [StringLength(200)]
        public string ApprovedBy { get; set; }
        public DateTime ApprovedAt { get; set; } = DateTime.Now;

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        [ForeignKey("MaintenanceFeeId")]
        public virtual MaintenanceFee MaintenanceFee { get; set; }
    }
}