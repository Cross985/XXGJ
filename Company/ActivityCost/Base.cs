using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using ActivityIncome.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : ActivityIncome  
 * Created On: 2014/8/22 15:10:44
 * Created By: Steven
 * 
 ************************************/

namespace ActivityIncome
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new ActivityIncomeSearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new ActivityIncomeListPage();
        }

        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new ActivityIncomeDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new ActivityIncomeDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new ActivityIncomeDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new ActivityIncomeDataPageDelete();
        }
    }
}