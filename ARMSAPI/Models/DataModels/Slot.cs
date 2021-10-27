using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class Slot : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Code { get; set; }
        public long SemesterId { get; set; }
        public int Round { get; set; }
        public bool IsSpecialSlot { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.Now;// ex. 26/06/2019 10:00-10:45
        public DateTime EndedAt { get; set; } = DateTime.Now;
        
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
        public virtual List<RegistrationSlot> RegistrationSlots { get; set; }

        [NotMapped]
        public long? AcademicLevelId 
        { 
            get
            {
                return Semester?.AcademicLevelId ;
            }
        }

        [NotMapped]
        public string Date 
        { 
            get
            {
                return StartedAt.ToShortDateString();
            }
        }

        [NotMapped]
        public string Start
        { 
            get
            {
                return StartedAt.ToString("HH:mm");
            }
        }

        [NotMapped]
        public string End
        { 
            get
            {
                return EndedAt.ToString("HH:mm");
            }
        }

        [NotMapped]
        public string SlotText 
        { 
            get
            {
                return $"{ Code } : { Date } { Start } - { End }";
            }
        }
    }
}