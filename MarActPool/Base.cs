using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using MarActPool.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : MarActPool  
 * Created On: 2014/8/8 14:53:44
 * Created By: thinkpad
 * 
 ************************************/

namespace MarActPool {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new MarActPoolSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new MarActPoolListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new MarActPoolDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new MarActPoolDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new MarActPoolDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new MarActPoolDataPageDelete();
        }
    }
}