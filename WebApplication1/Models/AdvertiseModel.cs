using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AdvertiseModel
    {
        [Key]
        public long UserId { get; set; }

        public int AdvertiseMessageId { get; set; }

    }
}