using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class CardExpirationOption : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        public long AcademicLevelId { get; set; }
        public long? FacultyId { get; set; }
        public long? DepartmentId { get; set; }
        
        [Required]
        public int ValidityYear { get; set; }

        [JsonIgnore]
        [ForeignKey("AcademicLevelId")]
        public virtual AcademicLevel AcademicLevel { get; set; }
        
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
        
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}