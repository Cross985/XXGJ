using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using OppoTrack.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : OppoTrack  
 * Created On: 2014/8/7 17:37:53
 * Created By: thinkpad
 * 
 ************************************/

namespace OppoTrack {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new OppoTrackSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new OppoTrackListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new OppoTrackDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new OppoTrackDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new OppoTrackDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new OppoTrackDataPageDelete();
        }
    }
}