using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Services;

namespace WebApplication1.Models
{
    public class Shop
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        public ProvinceModel Province{ get; set; }

        public CityModel City { get; set; }
        
        public string Shop_name { get; set; }

        public string Address { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string User_name { get; set; }

        public int Date { get; set; }

        public long Count { get; set; }

        public int EditMode { get; set; }

        public int RegisterCallbackButtonId { get; set; }

  


    }
}