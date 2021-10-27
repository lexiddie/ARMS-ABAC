using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class AnnouncementTopic
    {
        public long AnnouncementId { get; set; }
        public long TopicId { get; set; }

        [JsonIgnore]
        public virtual Announcement Announcement { get; set; }

        [JsonIgnore]
        public virtual Topic Topic { get; set; }
    }
}