using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;
using System.Linq;

namespace ARMSAPI.Models.DataModels.Curriculums
{
    public class CurriculumVersion : UserTimeStamp
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string Code { get; set; } //Curriculum ID
        public long CurriculumId { get; set; }
        public long? AcademicProgramId { get; set; }
        public long ImplementedSemesterId { get; set; }

        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }

        [StringLength(200)]
        public string DegreeNameEn { get; set; }

        [StringLength(200)]
        public string DegreeNameTh { get; set; }

        [StringLength(100)]
        public string DegreeAbbreviationEn { get; set; }

        [StringLength(100)]
        public string DegreeAbbreviationTh { get; set; }
        public long? OpenedSemesterId { get; set; } //Open Year/Semester
        public long? ClosedSemesterId { get; set; } //Close Year/Semester
        public int MinimumTerm { get; set; } //Minimum term to staudy
        public int ManximumTerm { get; set; } //Maximum term to study

        [StringLength(500)]
        public string Remark { get; set; }
        public DateTime ApprovedDate { get; set; }

        [ForeignKey("CurriculumId")]
        public virtual Curriculum Curriculum { get; set; }

        [ForeignKey("AcademicProgramId")]
        public virtual AcademicProgram AcademicProgram { get; set; }

        [ForeignKey("ImplementedSemesterId")]
        public virtual Semester Semester { get; set; }

        [ForeignKey("OpenedSemesterId")]
        public virtual Semester OpenedSemester { get; set; }

        [ForeignKey("ClosedSemesterId")]
        public virtual Semester ClosedSemester { get; set; }

        [JsonIgnore]
        public virtual List<CourseGroup> CourseGroups { get; set; }

        [JsonIgnore]
        public virtual List<StudyPlan> StudyPlans { get; set; }

        [JsonIgnore]
        public virtual List<CurriculumInstructor> CurriculumInstructors { get; set; }

        [NotMapped]
        public List<long> InstructorIds { get; set; }

        [NotMapped]
        public string CodeAndName
        { 
            get 
            {
                return $"{ Code } - { Curriculum?.AbbreviationEn ?? "" } { NameEn }"; 
            }
        }

        [NotMapped]
        public string ApprovedDateText
        { 
            get 
            {
                return ApprovedDate.ToShortDateString(); 
            }
        }

        [NotMapped]
        public List<IGrouping<int, StudyPlan>> PlanGroup { get; set; }
    }
}