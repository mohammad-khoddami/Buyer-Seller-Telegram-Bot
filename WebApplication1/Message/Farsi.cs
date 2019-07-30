using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Message
{
    public static class Farsi
    {
        public readonly static string StartCmt = "/start";
        //public readonly static string EditCmt = "/edit";
        //public readonly static string DeleteAccountCmt = "/deleteaccount";
        //public readonly static string ShopDetailsCmt = "/shopdetails";
        //public readonly static string ShopFieldsCmt = "/shopfields";
        public readonly static string FinishCmt = "/finish";
        public readonly static string SalesMan = "فروشنده";
        public readonly static string Buyer = "خریدار";
        public readonly static string SendOpinion = "ارسال پیشنهاد";
        public readonly static string Edit = "ویرایش";
        public readonly static string EditShopProfile = "ویرایش فروشگاه";
        public readonly static string DeleteShopProfile = "حذف فروشگاه";
        public readonly static string ShopDetails = "جزئیات فروشگاه";
        public readonly static string ShopFields = "محصولات فروشگاه";
        public readonly static string BuyerNewRequest = "درخواست خرید در دیگر شهر ها";
        public readonly static string EditKeyboard = "مشاهده و بررسی جزئیات فروشگاه یا جستجوی محصول در دیگر شهر ها :";
        public readonly static string Advertise = "تبلیغات";
        public readonly static string OpinionFormat = "ارسال نظر -";
        public readonly static string Opinion = "پیشنهاد خود را بفرستید\nکسری های محصولات و یا شهر ها را برای ما ارسال کنید تا آنرا اضافه کنیم\nپیام را به فرمت زیر ارسال کنید:\n"
            +OpinionFormat+" پیام شما";
        public readonly static string SendOpinionToAdmin = "#ارسال_نظر\n@{0}\n{1}";
        public readonly static string SalesManOrBuyer = "فروشنده ای یا خریدار ؟";
        public readonly static string SuccessRegistering = "ثبت نام شما با موفقیت انجام شده"/* + ShopDetailsCmt + " => نمایش اطلاعات فروشگاه\n" +
            ShopFieldsCmt + " => نمایش محصولات ثبت شده\n" + EditCmt + " => ویرایش اطلاعات فروشگاه\n" + DeleteAccountCmt + " => حذف فروشگاه/"*/;
        public readonly static string SelectProvince = "استان را انتخاب کن";
        public readonly static string SelectCity = "شهرت را انتخاب کن";
        public readonly static string SelectCategory = "دسته بندی محصولت را انتخاب کن";
        public readonly static string SubCategory = "زیر دسته:";
        public readonly static string BackButton = "\u2b05";
        public readonly static string ValidCity = "شهر {0} مطعلق به استان {1} نیست ";
        public readonly static string ExistField = "{0} در لیست محصولات شما قرار دارد ";
        public readonly static string EmptyFields = " لیست محصولات فروشگاه شما نمیتواند خالی باشد ";
        public readonly static string ShopName = "اسم فروشگاهت چیه ؟";
        public readonly static string SlashShopName = "نام فروشگاه نمیتواند شامل / باشد";
        public readonly static string LengthShopName = "نام مغازه باید کمتر از 30 کاراکتر باشد";
        public readonly static string ShopAddress = "خیابان اصلی مغازه را وارد کنید ";
        public readonly static string SlashShopAddress = "آدرس فروشگاه نمیتواند شامل / باشد";
        public readonly static string LengthShopAddress = "آدرس مغازه باید کمتر از 50 کاراکتر باشد";
        public readonly static string SaveFieldsReport = "محصولات {0} ذخیره شد";
        public readonly static string ShowSalesmanDetails = "{0} {1} \nفروشگاه شما با نام {2} در استان {3} شهر {4} خیابان {5} با محصولات {6}  در لیست فروشندگان قرار گرفت "/* +
            "\n\n" + EditCmt + " => ویرایش اطلاعات فروشگاه\n" + DeleteAccountCmt + " => حذف فروشگاه"*/;
        public readonly static string NotFoundSeller = "فروشنده ای یافت نشد"/*+"\n\n" + "/newrequest" + " => جستجوی محصول در سایر شهر ها"*/;
        public readonly static string QuestionForRemove = "چرا میخوای اطلاعاتت را حذف کنی؟";
        public readonly static string DontLikeThisBot = "باش حال نکردم";
        public readonly static string DontBeUsed = "به دردم نخورد";
        public readonly static string ClosedMyWork = "کسب و کارم تعطیل شد";
        public readonly static string AdminWhyDelete = DontLikeThisBot + " => {0}\n" + DontBeUsed + " => {1}\n" + ClosedMyWork + " => {2}";
        public readonly static string DeleteProfile = "اطلاعات شما حذف شد";
        public readonly static string FinishCmtBadPosition = "لیست ورود محصولات قبلا بسته شده" /*+ ShopFieldsCmt + " => نمایش محصولات ثبت شده"*/;
        public readonly static string WhereEdit = "کجا را میخوای ویرایش کنی؟";
        public readonly static string Province = "استان";
        public readonly static string City = "شهر";
        public readonly static string Fields = "محصولات";
        public readonly static string Name = "نام فروشگاه";
        public readonly static string Street = "خیابان";
        public readonly static string DuplicateSelection = "خب تو که قبلا هم {0} را انتخاب کرده بودی !";
        public readonly static string ShouldBeEditCity = "استان شما از {0} به {1} تغییر کرد";
        public readonly static string EditCity = "شهر شما از {0} به {1} تغییر کرد";
        public readonly static string SetCityWithCloseEditCity = "شما قبلا شهر {0} را انتخاب کرده اید";
        public readonly static string AddOrDeleteFields = "میخوای محصول مورد نظرت را حدف کنی یا به لیستت محصول جدید اضافه کنی؟";
        public readonly static string AddFieldEdit = "افزودن محصول";
        public readonly static string DeleteFieldEdit = "حذف محصول";
        public readonly static string WhichOneDelete = "هر کدوم را میخوای حذف کنی را انتخاب کن";
        public readonly static string DontExistInYourFields = "این محصول در لیست محصولات شما نیست";
        public readonly static string AbilityDeleteFields = "لیست محصولات نمیتواند خالی باشد قبل از حذف این محصول ،محصول دیگری را انتخاب کرده و سپس اقدام به حذف این محصول کنید ";
        public readonly static string SuccessDeleteField = "{0} از لیست محصولات شما حذف شد";
        public readonly static string DontEnterAnyField = "هنوز محصولی وارد نکرده اید";
        public readonly static string DoneAfterRegistering = "بعد تکمیل ثبت نام اقدام کنید";
        public readonly static string YouExistInSalesmans = "شما در لیست فروشندگان قرار گرفته اید ";
        public readonly static string DontYetEditCity = "شهر {0} در استان {1} نیست\nدر صورت عدم ویرایش شهر فروشگاه شما به خریداران نمایش داده نمی شود";
        public readonly static string CloseEdit = "ویرایش {0} بسته شد";
        public readonly static string SaveeField = "{0} ذخیره شد\n\n" + FinishCmt + " => پایان ورود محصولات";
        public readonly static string DuplicateName = "قبلا هم نام فروشگاه را {0} وارد کرده اید";
        public readonly static string EditShopNmae = "نام فروشگاه از {0} به {1} تغییر یافت";
        public readonly static string DuplicateShopAddr = "قبلا هم خیابان {0} را وارد کرده اید";
        public readonly static string EditShopAddr = "آدرس فروشگاه از {0} به {1} تغییر یافت";
        public readonly static string Help = "شما قبلا ثبت نام کرده اید \n /edit- ویرایش \n /deleteaccount- حذف فروشگاه \n /shopdetails- اطلاعات فروشگاه";
        public readonly static string SendMessage = " پیام خود را به فروشندگان بفرستید ";
       // public readonly static string NewRequestCmd = "/newrequest";
        public readonly static string SendMessageForAll = "خریدار #{0} :\n#{1}{2}\n{3}";
        public readonly static string SendForAll = "پیام شما برای {0} فروشنده از {1} فروشنده ی {2} در استان {3} شهر {4} ارسال شد\n\n" /*+ NewRequestCmd + " => جستجوی محصول در سایر شهر ها"*/;
        public readonly static string SellerToBuyer = "فروشنده #{0} :\nفروشگاه #{1}\n{2}";
        public readonly static string AdvertiseDescription = "آگهی خود را به همان صورت که میخواهید به فروشندهگان ارسال کنید بفرستید";
    }
}