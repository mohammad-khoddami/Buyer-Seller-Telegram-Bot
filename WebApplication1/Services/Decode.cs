using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class Decode
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        List<string> list = new List<string>();
        public string[] Decoding(int[] codes)
        {
            int x;
            for(int i = 0; i < codes.Length; i++)
            {
                if (codes[i] != -1)
                {
                    x = codes[i];
                    list.Add(_db.MinorCategories.FirstOrDefault(t => t.Id ==x ).Name);
                }
                }
            return list.ToArray();
        }
    }
}