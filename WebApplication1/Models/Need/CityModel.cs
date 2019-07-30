using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class CityModel
    {
        [Key]
        public string Id { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string Name { get; set; }

    }
}