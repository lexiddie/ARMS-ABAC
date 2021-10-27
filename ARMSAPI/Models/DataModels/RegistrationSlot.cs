using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class RegistrationSlot : UserTimeStamp
    {
        public long Id { get; set; }
        public long SlotId { get; set; }
        public long? StudentId { get; set; } // case : open slot for one student
        public long? AcademicProgramId { get; set; }
        public long? FacultyId { get; set; }
        public long? DepartmentId { get; set; }
        public int BatchCodeStart { get; set; }
        public int BatchCodeEnd { get; set; }
        public int LastDigitStart { get; set; }
        public int LastDigitEnd { get; set; }
        public bool IsGraduating { get; set; }
        public bool IsAthlete { get; set; }

        [ForeignKey("SlotId")]
        public virtual Slot Slot { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("AcademicProgramId")]
        public virtual AcademicProgram AcademicProgram { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [NotMapped]
        public string StudentCode { get; set; }

        [NotMapped]
        public List<long> SlotIds { get; set; }

        [NotMapped]
        public string Batch 
        { 
            get
            {
                if (BatchCodeStart == 0  && BatchCodeEnd == 0)
                {
                    return "";
                }
                else
                {
                    return $"{ (BatchCodeStart == 0 ? "xxx" : BatchCodeStart.ToString()) } - { (BatchCodeEnd == 0 ? "xxx" : BatchCodeEnd.ToString()) }";
                }
            }
        }

        [NotMapped]
        public string LastDigit 
        { 
            get
            {
                if (LastDigitStart == 0  && LastDigitEnd == 0)
                {
                    return "";
                }
                else
                {
                    return $"{ LastDigitStart } - { LastDigitEnd }";
                }
            }
        }
    }
}