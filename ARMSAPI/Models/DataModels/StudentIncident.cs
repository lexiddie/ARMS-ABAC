using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ARMSAPI.Models.DataModels.MasterTables;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels
{
    public class StudentIncident : UserTimeStamp
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long IncidentId { get; set; }
        public bool LockedDocument { get; set; }
        public bool LockedRegistration { get; set; }
        public bool LockedPayment { get; set; }
        public bool LockedVisa { get; set; }
        public bool LockedGraduation { get; set; }
        public bool LockedChangeFaculty { get; set; }
        
        [JsonIgnore]
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("IncidentId")]
        public virtual Incident Incident { get; set; }
    }
}
