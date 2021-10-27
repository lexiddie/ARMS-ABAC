using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.Curriculums
{
    public class CourseGroup : UserTimeStamp
    {
        public CourseGroup()
        {
            ChildCourseGroups = new List<CourseGroup>();
        }

        public long Id { get; set; }
        public long CurriculumVersionId { get; set; }
        public long? CourseGroupId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }

        [StringLength(500)]
        public string DescriptionEn { get; set; }

        [StringLength(500)]
        public string DescriptionTh { get; set; }
        public decimal Credit { get; set; }
        public long? MinorId { get; set; }
        public long? ConcentrationId { get; set; }

        [NotMapped]
        public bool HasChild { get; set; }

        [NotMapped]
        public string CreditText 
        { 
            get 
            { 
                return Credit.ToString("G29"); 
            } 
        }

        [ForeignKey("CurriculumVersionId")]
        public virtual CurriculumVersion CurriculumVersion { get; set; }

        [JsonIgnore]
        [ForeignKey("CourseGroupId")]
        public virtual CourseGroup ParentGroup { get; set; }

        [ForeignKey("MinorId")]
        public virtual Minor Minor { get; set; }

        [ForeignKey("ConcentrationId")]
        public virtual Concentration Concentration { get; set; }
        public virtual ICollection<CourseGroup> ChildCourseGroups { get; set; }
        public virtual ICollection<CurriculumCourse> CurriculumCourses { get; set; }
    }
}