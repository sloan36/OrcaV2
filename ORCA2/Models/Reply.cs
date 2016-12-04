using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORCA2.Models
{
    public class Reply
    {
        [Key]
        public int ReplyID { get; set; }
        public int MessageID { get; set; }
      
        public int ID { get; set; }
        [DataType(DataType.MultilineText)]
        public String Content { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Timestamp { get; set; }
    }
}