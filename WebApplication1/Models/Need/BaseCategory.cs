﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BaseCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
    }
}