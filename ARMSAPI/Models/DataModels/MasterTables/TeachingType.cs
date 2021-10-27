using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class TeachingType : UserTimeStamp
    {
        public long Id { get; set; }
        
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }
        
        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }

        [Required]
        [StringLength(5)]
        public string CalculateType { get; set; }
        public bool IsLoadCalculation { get; set; }
        public int Priority { get; set; }

        [Required]
        public decimal LoadConverter { get; set; } = 1;
        //ex. 2 Lab = 1 Lecture Load --> Lab type load converter = 0.5 

        [NotMapped]
        public string CalculateTypeText 
        { 
            get
            {
                if (CalculateType == "s")
                {
                    return "Per Student";
                }
                else if (CalculateType == "h")
                {
                    return "Per Hour";
                }
                else
                {
                    return "Not Specify";
                }
            }
        }

        [NotMapped]
        public string LoadConverterText 
        { 
            get
            {
                return LoadConverter.ToString("G29");
            }
        }
    }
}