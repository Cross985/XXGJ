using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using CompeMarAct.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : CompeMarAct  
 * Created On: 2014/8/8 16:27:32
 * Created By: thinkpad
 * 
 ************************************/

namespace CompeMarAct {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new CompeMarActSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new CompeMarActListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new CompeMarActDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new CompeMarActDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new CompeMarActDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new CompeMarActDataPageDelete();
        }
    }
}