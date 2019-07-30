using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DeleteUserModels
    {
        [Key]
        public long UserId { get; set; }

        public int WhyDlt { get; set; }

    }
}