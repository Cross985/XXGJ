using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using ProdType.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : ProdType  
 * Created On: 2014/8/8 12:50:53
 * Created By: thinkpad
 * 
 ************************************/

namespace ProdType {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new ProdTypeSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new ProdTypeListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new ProdTypeDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new ProdTypeDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new ProdTypeDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new ProdTypeDataPageDelete();
        }
    }
}