using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using OppoCompetitor.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : OppoCompetitor  
 * Created On: 2014/8/8 10:03:57
 * Created By: thinkpad
 * 
 ************************************/

namespace OppoCompetitor {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new OppoCompetitorSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new OppoCompetitorListPage();
        }

        public static void RunCompetitorListPage(ref Web AretVal) {
            AretVal = new CompetitorListPage();
        }
        public static void RunDataPage(ref Web AretVal) {
            AretVal = new OppoCompetitorDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new OppoCompetitorDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new OppoCompetitorDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new OppoCompetitorDataPageDelete();
        }
    }
}