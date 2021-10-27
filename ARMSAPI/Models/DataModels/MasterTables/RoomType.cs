using System;
using System.ComponentModel.DataAnnotations;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class RoomType : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}