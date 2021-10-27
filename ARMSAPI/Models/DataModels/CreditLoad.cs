using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;

namespace ARMSAPI.Models.DataModels
{
    public class CreditLoad : UserTimeStamp
    {
        public long Id { get; set; }
        public long SemesterId { get; set; }
        public long? FacultyId { get; set; }
        public long? DepartmentId { get; set; }
        public bool IsGraduating { get; set; }
        public decimal MaxGPA { get; set; }
        public decimal MinGPA { get; set; }
        public decimal MaxCredit { get; set; }
        public decimal MinCredit { get; set; }

        [NotMapped]
        public string MaxCreditText 
        { 
            get 
            { 
                return MaxCredit.ToString("G29"); 
            } 
        }

        [NotMapped]
        public string MinCreditText
        { 
            get 
            { 
                return MinCredit.ToString("G29"); 
            } 
        }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set;}

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set;}

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set;}
    }
}