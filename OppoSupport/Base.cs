using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using OppoSupport.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : OppoSupport  
 * Created On: 2014/8/8 9:46:03
 * Created By: thinkpad
 * 
 ************************************/

namespace OppoSupport {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new OppoSupportSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new OppoSupportListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new OppoSupportDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new OppoSupportDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new OppoSupportDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new OppoSupportDataPageDelete();
        }
    }
}