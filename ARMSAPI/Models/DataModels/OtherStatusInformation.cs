using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class OtherStatusInformation : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentId { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [NotMapped]
        public string TypeText 
        { 
            get
            {
                if (this.Type == "reenter")
                {
                    return "Re-Enter";
                }
                else if (this.Type == "resign")
                {
                    return "Resign";
                }
                else if (this.Type == "retire")
                {
                    return "Retire";
                }
                else 
                {
                    return "Leave";
                }
            }
        }

        [Required]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime EffectiveDate { get; set; }
        
        [StringLength(1000)]
        public string Reason { get; set; }

        [StringLength(200)]
        public string ApprovedBy { get; set; }
        public DateTime ApprovedAt { get; set; }
        
        [JsonIgnore]
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
