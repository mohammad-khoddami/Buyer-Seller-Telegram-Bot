using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CategoriesService
    {
        public MinorCategory[] MinorCategories(int id)
        {
            if (id == 1)
            {
                MinorCategory[] mc = new[]{ new MinorCategory {Name="موبایل",Id=1 },
                   new MinorCategory {Name="تبلت و کتابخان",Id=2 },
                   new MinorCategory { Name="لپ تاپ",Id=3 },
                   new MinorCategory {Name= "دوربین",Id=4 },
                   new MinorCategory {Name= "کامپیوتر و تجهیزات جانبی",Id=5 },
                   new MinorCategory {Name="ماشین های اداری",Id=6 },
                   new MinorCategory {Name="لوازم جانبی کالای دیجیتال",Id=7}
                };
                return mc;
            }
            else if (id == 2)
            {
                MinorCategory[] mc = new[]{
                    new MinorCategory {Name="صوتی و تصویری",Id=8},
                    new MinorCategory { Name="لوازم خانگی برقی",Id=9 },
                    new MinorCategory {Name="آشپزخانه",Id=10},
                    new MinorCategory {Name= "سرو و پذیرایی",Id=11 },
                    new MinorCategory {Name= "دکوراتیو",Id=12 },
                    new MinorCategory {Name="فرش",Id=13},
                    new MinorCategory {Name="خواب و حمام",Id=14},
                    new MinorCategory {Name= "شستشو و نظافت",Id=15}
                };
                return mc;
            }
            else if (id == 3)
            {
                MinorCategory[] mc = new[]{new MinorCategory {Name= "عطر",Id=16 },
                    new MinorCategory {Name= "لوازم آرایشی",Id=17 },
                    new MinorCategory {Name= "لوازم بهداشتی",Id=18 },
                    new MinorCategory {Name= "لوازم شخصی برقی",Id=19 },
                    new MinorCategory {Name= "ساعت",Id=20 },
                    new MinorCategory {Name= "عینک آفتابی",Id=21 },
                    new MinorCategory {Name= "زیورآلات",Id=22 },
                    new MinorCategory {Name="ابزار سلامت",Id=23 },
                    new MinorCategory {Name="اکسسوری لوازم شخصی",Id=24 }
                };
                return mc;
            }
            else if (id == 4)
            {
                MinorCategory[] mc = new[]{new MinorCategory {Name= "کتاب و مجلات",Id=25 },
                    new MinorCategory {Name="لوازم التحریر",Id=26 },
                    new MinorCategory { Name = "صنایع دستی", Id = 27 },
                    new MinorCategory { Name="فرش",Id=28 },
                    new MinorCategory {Name= "آلات موسیقی",Id=29},
                    new MinorCategory {Name= "موسیقی",Id=30 },
                    new MinorCategory {Name= "فیلم",Id=31 },
                    new MinorCategory {Name= "نرم افزار و بازی",Id=32 },
                    new MinorCategory {Name= "محتوای آموزشی",Id=33 }};
                return mc;
            }
            else if (id == 5)
            {
                MinorCategory[] mc = new[]{new MinorCategory {Name= "پوشاک ورزشی",Id=34 },
                    new MinorCategory {Name= "کفش ورزشی",Id=35 },
                    new MinorCategory {Name= "لوازم ورزشی",Id=36 },
                    new MinorCategory {Name= "دوچرخه و لوازم جانبی",Id=37},
                    new MinorCategory {Name= "تجهیزات سفر",Id=38 },
                    new MinorCategory {Name= "اسباب بازی",Id=39  } };
                return mc;
            }
            else if (id == 6)
            {
                MinorCategory[] mc = new[]{new MinorCategory {Name="ایمنی و مراقبت",Id=40 },
                    new MinorCategory {Name= "غذاخوری",Id=41 },
                    new MinorCategory {Name= "لوازم شخصی",Id=42 },
                    new MinorCategory {Name= "بهداشت و حمام",Id=43 },
                    new MinorCategory {Name= "گردش و سفر",Id=44 },
                    new MinorCategory {Name= "سرگرمی و آموزشی",Id=45 },
                    new MinorCategory {Name= "خواب کودک",Id=46 },
                    new MinorCategory {Name= "لباس کودک و نوزاد",Id=47 } };
                return mc;
            }
            else if (id == 7)
            {
                MinorCategory[] mc = new[]{new MinorCategory {Name= "ابزارغیربرقی",Id=48},
                    new MinorCategory {Name= "ابزاربرقی و شارژی",Id=49 },
                    new MinorCategory {Name= "لوازم باغبانی",Id=50 },
                    new MinorCategory {Name= "نور و روشنایی",Id=51 } };
                return mc;
            }
            else if (id == 8)
            {
                MinorCategory[] mc = new[]{ new MinorCategory{Name="خودرو",Id=52 },
                    new MinorCategory {Name= "لوازم جانبی خودرو",Id=53 },
                    new MinorCategory {Name= "لوازم مصرفی خودرو",Id=54 } };
                return mc;
            }
            return null;
        }

        public BaseCategory[] BaseCategories()
        {
            BaseCategory[] bc = new[] { new BaseCategory  { Name = "کالای دیجیتال", Id = 1 },
            new BaseCategory { Name = "لوازم خانگی",Id=2 },
            new BaseCategory { Name = "زیبایی و سلامت", Id = 3 },
            new BaseCategory { Name = "فرهنگ و هنر", Id = 4 },
            new BaseCategory { Name = "ورزش و سرگرمی", Id = 5 },
            new BaseCategory { Name = "مادر و کودک", Id = 6 },
            new BaseCategory { Name = "ابزار الکتریک", Id = 7 },
            new BaseCategory { Name = "خودرو و لوازم", Id = 8 }};
            return bc;
        }
    }
}