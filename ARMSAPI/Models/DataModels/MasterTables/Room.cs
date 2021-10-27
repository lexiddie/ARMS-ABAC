using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class Room : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public int ExamCapacity {get; set;}
        public int ExamRows {get; set; }
        public bool IsAllowAutoAssign { get; set; }

        [NotMapped]
        public int ExamSeatPerRow
        {
            get 
            { 
                return (ExamCapacity/ExamRows);
            }
        }

        public long BuildingId { get; set; }
        public long RoomTypeId { get; set; }

        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }

        [ForeignKey("RoomTypeId")]
        public virtual RoomType RoomType { get; set; }

        [NotMapped]
        public long CampusId
        {
            get
            {
                return Building == null ? 0 : Building.CampusId;
            }
        }
    }
}