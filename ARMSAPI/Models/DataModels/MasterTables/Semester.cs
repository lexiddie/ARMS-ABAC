using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.MasterTables 
{
    public class Semester : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        public long AcademicLevelId { get; set; }

        [Required]
        public int AcademicYear { get; set; }

        [Required]
        public int Term { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? StartedAt { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? EndedAt { get; set; }
        public decimal TotalWeeksCount { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsAdvising { get; set; }
        public bool IsRegistration { get; set; }

        [ForeignKey("AcademicLevelId")]
        public virtual AcademicLevel AcademicLevel { get; set;}

        public virtual List<ExaminationSlot> ExaminationSlots {get; set;}

        [NotMapped]
        public string SemesterText 
        { 
            get
            {
                return $"{ Term }/{ AcademicYear }";
            }
        }

        [NotMapped]
        public string TotalCountText 
        { 
            get
            {
                return TotalWeeksCount.ToString("G29");
            }
        }

        [NotMapped]
        public string StartedDate 
        { 
            get
            {
                return StartedAt?.ToShortDateString();
            }
        }
        
        [NotMapped]
        public string EndedDate 
        { 
            get
            {
                return EndedAt?.ToShortDateString();
            }
        }
    }
}
