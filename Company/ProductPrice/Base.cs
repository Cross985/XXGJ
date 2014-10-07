using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using ProductPrice.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : ProductPrice  
 * Created On: 2014/8/22 15:10:44
 * Created By: Steven
 * 
 ************************************/

namespace ProductPrice
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new ProductPriceSearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new ProductPriceListPage();
        }

        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new ProductPriceDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new ProductPriceDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new ProductPriceDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new ProductPriceDataPageDelete();
        }
    }
}