using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.Curriculums
{
    public class StudyPlan : UserTimeStamp
    {
        public long Id { get; set; }
        public long CurriculumVersionId { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public int TotalCredit { get; set; }

        [ForeignKey("CurriculumVersionId")]
        public virtual CurriculumVersion CurriculumVersion { get; set; }
        public virtual List<StudyCourse> StudyCourses { get; set; }

        [NotMapped]
        private readonly static string[] yearString = new string[] { "Zero", "First", "Second", "Third", "Fouth",
                                                                     "Fifth", "Sixth", "Seventh", "Eighth" };

        [NotMapped]
        public string YearText 
        { 
            get
            {
                return yearString[Year];
            }
        }

        [NotMapped]
        public string TotalCreditText 
        { 
            get
            {
                return TotalCredit.ToString("G29");
            }
        }
        
    }
}