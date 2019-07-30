using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class ProvinceModel
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }

    }
}