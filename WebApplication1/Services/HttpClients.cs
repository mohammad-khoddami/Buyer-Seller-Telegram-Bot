using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class HttpClients
    {
        public ProvinceModel[] GetProvince()
        {
            using (HttpClient client = new HttpClient())
            {
                var Json = client.GetStringAsync("https://uandshop.com/api/location/provinces?country=iran");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ProvinceModel[]>(Json.Result);
            }
        }

        public CityModel[] GetCities(string prc)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var Json = client.GetStringAsync($"https://uandshop.com/api/location/cities?province={prc}");
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<CityModel[]>(Json.Result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new CityModel[0];
        }
    }
}