using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class GraduationInformation : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentId { get; set; }

        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime? GraduatedDate { get; set; }

        [StringLength(100)]
        public string Class { get; set; }
        public long? SemesterId { get; set; }
        public long? HonorId { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [StringLength(500)]
        public string ThesisRemark { get; set; }

        [StringLength(1000)]
        public string OtherRemark1 { get; set; }

        [StringLength(1000)]
        public string OtherRemark2 { get; set; }

        [JsonIgnore]
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        [ForeignKey("HonorId")]
        public virtual AcademicHonor AcademicHonor { get; set; }
    }
}
