using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class CheatingStatus : UserTimeStamp
    {
       public long Id { get; set; }
       public long StudentId { get; set; }
       public long CourseId { get; set; }
       public long SectionId { get; set; }
       public long ExaminationTypeId { get; set; }
       public long? IncidentId { get; set; }
       public long? FromSemesterId { get; set; }
       public long? ToSemesterId { get; set; }
       public bool PaidStatus { get; set; }
       
       [StringLength(500)]
       public string Detail { get; set; }

       [StringLength(200)]
       public string ApprovedBy { get; set; }
       public DateTime ApprovedAt { get; set; }

       [ForeignKey("StudentId")]
       public virtual Student Student { get; set; }

       [ForeignKey("CourseId")]
       public virtual Course Course { get; set; }

       [ForeignKey("SectionId")]
       public virtual Section Section { get; set; }

       [ForeignKey("ExaminationTypeId")]
       public virtual ExaminationType ExaminationType { get; set; }

       [ForeignKey("IncidentId")]
       public virtual Incident Incident { get; set; }

       [ForeignKey("FromSemesterId")]
       public virtual Semester FromSemester { get; set; }

       [ForeignKey("ToSemesterId")]
       public virtual Semester ToSemester { get; set; }
    }
}