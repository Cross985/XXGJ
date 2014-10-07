using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using DecorateComp.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : DecorateComp  
 * Created On: 2014/8/8 14:18:40
 * Created By: thinkpad
 * 
 ************************************/

namespace DecorateComp {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new DecorateCompSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new DecorateCompListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new DecorateCompDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new DecorateCompDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new DecorateCompDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new DecorateCompDataPageDelete();
        }
        public static void RunPersonSummary(ref Web AretVal) {
            AretVal = new PersonSummary();
        }
        public static void RunPersonAdd(ref Web AretVal) {
            AretVal = new PersonAdd();
        }
        public static void RunPersonEdit(ref Web AretVal) {
            AretVal = new PersonEdit();
        }
        public static void RunPersonDelete(ref Web AretVal) {
            AretVal = new PersonDelete();
        }
    }
}