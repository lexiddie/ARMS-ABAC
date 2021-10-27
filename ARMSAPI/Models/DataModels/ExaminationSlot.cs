using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class ExaminationSlot : UserTimeStamp
    {
        public long Id { get; set; }
        public long SemesterId { get; set; }
        public long AcademicLevelId { get; set; }
        public long ExaminationTypeId {get; set;}
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Date { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    

        

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        [ForeignKey("AcademicLevelId")]
        public virtual AcademicLevel AcademicLevel {get; set;}
        [ForeignKey("ExaminationTypeId")]
        public virtual ExaminationType ExaminationType {get; set;}

       
    }
}