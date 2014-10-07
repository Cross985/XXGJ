using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Quotation.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : Quotation  
 * Created On: 2014/8/10 17:58:29
 * Created By: Steven
 * 
 ************************************/

namespace Quotation
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new QuotationSearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new QuotationListPage();
        }

        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new QuotationDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new QuotationDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new QuotationDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new QuotationDataPageDelete();
        }
        public static void RunQDAdd(ref Web AretVal)
        {
            AretVal = new QDAdd();
        }

        public static void RunQDEdit(ref Web AretVal)
        {
            AretVal = new QDEdit();
        }
        public static void RunQDDelete(ref Web AretVal)
        {
            AretVal = new QuotationDetailDelete();
        }
    }
}