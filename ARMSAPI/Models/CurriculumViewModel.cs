using System.Collections.Generic;
using ARMSAPI.Models.DataModels.Curriculums;

namespace ARMSAPI.Models
{
    public class CurriculumViewModel
    {
        public Curriculum Curriculum { get; set; }
        public CurriculumVersion Version { get; set; }
        public List<long> InstructorIds { get; set; }
    }
}