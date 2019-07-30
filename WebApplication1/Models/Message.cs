using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Message
    {
        
        public long RequestId { get; set; }

        [ForeignKey("RequestId")]
        public Request Request { get; set; }

        [Key, Column(Order = 1)]
        public long DUserId { get; set; }

        public long SUserId { get; set; }

        public int SourceMessage { get; set; }
        [Key,Column(Order =0)]
        public int DestinationMessage { get; set; }

    }
}