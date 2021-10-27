using System.ComponentModel.DataAnnotations;

namespace ARMSAPI.Models.DataModels
{
    public class Grade : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(5)]
        public string Letter { get; set; }
        public decimal? Weight { get; set; }
    } 
}