using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ShopService
    {
        ApplicationDbContext _db;

        public ShopService()
        {
            _db = new ApplicationDbContext();
        }

        public bool Exist(long userId)
        {
            return _db.Shops.Any(t => t.UserId == userId);
        }

        public bool ExistPrc(long userId)
        {
            return _db.Shops.Where(t => t.UserId == userId && t.Province != null).Any();
        //    if (_db.Shops.Include("Province").FirstOrDefault(t => t.UserId == userId).Province != null)
        //        return true;
        //    return false;
        }

        public bool ExistCty(long userId)
        {
            return _db.Shops.Where(t => t.UserId == userId && t.City != null).Any();
        //    if (_db.Shops.Include("City").FirstOrDefault(t => t.UserId == userId).City != null)
        //        return true;
        //    return false;
        }

        public bool ExistFld(long userId)
        {
            var userfld = _db.Fields.Where(t => t.UserId == userId).Select(t => t.FieldId).ToArray();
            if (userfld != null && Array.Exists(userfld, t => t == -1)&&userfld.Length>1)
                return true;
            return false; 
        }

        public bool Existmorethanonefld(long userId)
        {
            var userfld = _db.Fields.Where(t => t.UserId == userId).Count();
            if (userfld==0)
                return false;
            return true;
        }

        public bool RepeatedlyFld(long userId,int fldId)
        {
            var userfld = _db.Fields.Where(t => t.UserId == userId).Select(t => t.FieldId).ToArray();
            if (Array.Exists(userfld, t => t == fldId))
                return true;
            return false;
        }

        public bool ClosedFld(long userId)
        {
            var userfld = _db.Fields.Where(t => t.UserId == userId).Select(t => t.FieldId).ToArray();
            if (Array.Exists(userfld, t => t == -1))
                return true;
            return false;
        }

        public bool ExistShpName(long userId)
        {
            return _db.Shops.Where(t => t.UserId == userId && t.Shop_name != null).Any();
        }

        public bool CheckForDbSaveShopNameAndAddr(long userId)
        {
            if (ExistPrc(userId) && ExistCty(userId) && ExistFld(userId))
                return true;
            return false;
        }
        
        
        public bool ExistShpAddr(long userId)
        {
            return _db.Shops.Where(t => t.UserId == userId && t.Address != null).Any();
        //    if (_db.Shops.FirstOrDefault(t => t.UserId == userId).Address != null)
        //        return true;
        //    return false;
        }
        public bool SalesmanRegCpt(long userId)
        {
            if (Exist(userId) && ExistPrc(userId) && ExistCty(userId) && ExistFld(userId) && ExistShpName(userId) && ExistShpAddr(userId))
                return true;
            return false;
        }

        //public bool ExistShpPhone(int userId)
        //{
        //    if (_db.Shops.FirstOrDefault(t => t.UserId == userId).Phone!= null)
        //        return true;
        //    return false;
        //}

        //public bool ExistFirstName(long userId)
        //{
        //    if (_db.Shops.FirstOrDefault(t => t.UserId == userId).First_name!= null)
        //        return true;
        //    return false;
        //}

        //public bool ExistLastName(long userId)
        //{
        //    if (_db.Shops.FirstOrDefault(t => t.UserId == userId).Last_name!= null)
        //        return true;
        //    return false;
        //}

        //public bool ExistUserName(long userId)
        //{
        //    if (_db.Shops.FirstOrDefault(t => t.UserId == userId).User_name!= null)
        //        return true;
        //    return false;
        //}


        //public bool ExitDate(long userId)
        //{
        //    if (_db.Shops.FirstOrDefault(t => t.UserId == userId).Date!= null)
        //        return true;
        //    return false;
        //}

        //public bool CheckProvince(string txt)
        //{
        //    if (_db.Provinces.Any(t => t.Key == txt))
        //        return true;
        //    return false;
        //}

        //public bool CheckCities(string txt)
        //{
        //    if (_db.Cities.Any(t => t.Name == txt))
        //        return true;
        //    return false;
        //}

    }
}               