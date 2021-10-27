using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels
{
    public class CourseEquivalent
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public long EquilaventCourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("EquilaventCourseId")]
        public virtual Course EquilaventCourse { get; set; }
    }
}