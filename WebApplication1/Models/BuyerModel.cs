using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Services;
using Telegram.Bot.Types;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class BuyerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public int MessageId { get; set; }

        public ProvinceModel Province { get; set; }

        public CityModel City { get; set; }

        public MinorCategory FieldId { get; set; }

        public int SendForAll { get; set; }//1 is true &0 is false
    }
}