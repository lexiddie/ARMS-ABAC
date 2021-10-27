using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class Topic : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(200)]
        public string NameTh { get; set; }
        public long? FacultyId { get; set; }
        public long? DepartmentId { get; set; }
        public long ChannelId { get; set; }

        [StringLength(2100)]
        public string LogoUrl { get; set; }

        [JsonIgnore]
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty  { get; set; }

        [JsonIgnore]
        [ForeignKey("DepartmentId")]
        public virtual Department Department  { get; set; }

        [JsonIgnore]
        [ForeignKey("ChannelId")]
        public virtual Channel Channel  { get; set; }
    }
}