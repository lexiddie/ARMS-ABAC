using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.Curriculums
{
    public class CurriculumCourse : UserTimeStamp
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public long CourseGroupId { get; set; }
        public bool IsRequired { get; set; }

        [StringLength(5)]
        public string RequiredGrade { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [JsonIgnore]
        [ForeignKey("CourseGroupId")]
        public virtual CourseGroup CourseGroup { get; set; }
    }
}