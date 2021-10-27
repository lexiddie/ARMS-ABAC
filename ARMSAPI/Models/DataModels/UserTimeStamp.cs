using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels
{
    public class UserTimeStamp : Entity
    {
        DateTime _current = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime CreatedAt { get; set; }

        [StringLength(200)]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime UpdatedAt { get; set; }

        [StringLength(200)]
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; } = true;

        [NotMapped]
        public string LastUpdate 
        { 
            get
            {
                return $"{ UpdatedAt.ToString(DateTimeStringFormat.ShortDateTime) } by { UpdatedBy }";
            } 
        }

        public override void OnBeforeInsert(string by)
        {
            this.CreatedAt = _current;
            this.CreatedBy = by;
            this.UpdatedAt = _current;
            this.UpdatedBy = by;
        }

        public override void OnBeforeUpdate(string by)
        {
            this.UpdatedAt = _current;
            this.UpdatedBy = by;
        }
    }
}