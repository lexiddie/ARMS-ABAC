using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.Curriculums
{
    public class StudyCourse
    {
        public long Id { get; set; }
        public long StudyPlanId { get; set; }
        public long? CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(100)]
        public string NameTh { get; set; }
        public decimal Credit { get; set; }

        [ForeignKey("StudyPlanId")]
        public virtual StudyPlan StudyPlan { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [NotMapped]
        public string Name 
        { 
            get
            {
                if (CourseId == null)
                {
                    return NameEn;
                }
                else
                {
                    return Course.NameEn;
                }
            }
        }
    }
}