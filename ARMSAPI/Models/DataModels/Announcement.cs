using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ARMSAPI.Models.DataModels.MasterTables
{
    public class Announcement : UserTimeStamp
    {
        public long Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [StringLength(2100)]
        public string CoverImageURL { get; set; }

        //Json Object
        // { Name, Type, Thumbnail }
        //
        [StringLength(5000)]
        public string Attachments { get; set; }
        
        [StringLength(5000)]
        public string HTMLBody { get; set; }
        
        [StringLength(2100)]
        public string DetailWebUrl { get; set; }

        [Required]
        public bool IsFlagged { get; set; }

        [Required]
        public long ChannelId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd'/'MM'/'yyyy HH:mm")]
        public DateTime StartedAt { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd'/'MM'/'yyyy HH:mm")]
        public DateTime ExpiredAt { get; set; }

        [ForeignKey("ChannelId")]
        public virtual Channel Channel { get; set; }

        [NotMapped]
        public List<long> Topics { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<AnnouncementTopic> AnnouncementTopics { get; set; }
    }
}