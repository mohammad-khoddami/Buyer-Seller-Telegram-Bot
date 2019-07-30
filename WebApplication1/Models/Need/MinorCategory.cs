﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MinorCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}