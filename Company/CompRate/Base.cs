using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using CompRate.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : CompRate  
 * Created On: 2014/8/22 15:10:44
 * Created By: Steven
 * 
 ************************************/

namespace CompRate
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new CompRateSearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new CompRateListPage();
        }

        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new CompRateDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new CompRateDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new CompRateDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new CompRateDataPageDelete();
        }
    }
}