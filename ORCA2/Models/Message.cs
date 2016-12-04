using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ORCA2.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public int User1ID { get; set; }
        public int User2ID { get; set; }
        public String Title { get; set; }
        [DataType(DataType.MultilineText)]
        public String InitialMessage { get; set; }
    }
}