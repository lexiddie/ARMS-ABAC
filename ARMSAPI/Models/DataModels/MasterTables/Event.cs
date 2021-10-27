using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class Event : UserTimeStamp
    {
        public long Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }
        public long EventCategoryId { get; set; }

        [JsonIgnore]
        [ForeignKey("EventCategoryId")]
        public virtual EventCategory EventCategory { get; set; }
    }   
}