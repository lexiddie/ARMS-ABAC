using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class Building : UserTimeStamp
    {
        
        public long Id { get; set; } 

        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(200)] 
        public string NameTh { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public int FloorNumber { get; set; }
        public long CampusId { get; set; }

        
        [ForeignKey("CampusId")]
        public virtual Campus Campus { get; set;}
        public virtual List<Room> Rooms {get; set;}
    }
}