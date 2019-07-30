using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Field
    {
        [Key,Column(Order =0)]        
        public long UserId { get; set; }
        [Key,Column(Order =1)]
        public int FieldId { get; set; }    
    }
}