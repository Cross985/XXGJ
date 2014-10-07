using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using MarketInfo.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : MarketInfo  
 * Created On: 2012/3/25 22:53:08
 * Created By: Administrator
 * 
 ************************************/

namespace MarketInfo
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new MarketInfoSearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new MarketInfoListPage();
        }

        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new MarketInfoDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new MarketInfoDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new MarketInfoDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new MarketInfoDataPageDelete();
        }

        public static void RunBrandRateSummary(ref Web AretVal)
        {
            AretVal = new BrandRateSummary();
        }
        public static void RunBrandRateAdd(ref Web AretVal)
        {
            AretVal = new BrandRateAdd();
        }
        public static void RunBrandRateEdit(ref Web AretVal)
        {
            AretVal = new BrandRateEdit();
        }
        public static void RunBrandRateDelete(ref Web AretVal)
        {
            AretVal = new BrandRateDelete();
        }
    }
}