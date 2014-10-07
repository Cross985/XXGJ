using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Maintenance.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : Maintenance  
 * Created On: 2014/8/8 17:18:56
 * Created By: thinkpad
 * 
 ************************************/

namespace Maintenance {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new MaintenanceSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new MaintenanceListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new MaintenanceDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new MaintenanceDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new MaintenanceDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new MaintenanceDataPageDelete();
        }
        public static void RunMainteDetailSummary(ref Web AretVal) {
            AretVal = new MainteDetailSummary();
        }
        public static void RunMainteDetailAdd(ref Web AretVal) {
            AretVal = new MainteDetailAdd();
        }
        public static void RunMainteDetailEdit(ref Web AretVal) {
            AretVal = new MainteDetailEdit();
        }
        public static void RunMainteDetailDelete(ref Web AretVal) {
            AretVal = new MainteDetailDelete();
        }
        public static void RunBadTypeSummary(ref Web AretVal) {
            AretVal = new BadTypeSummary();
        }
        public static void RunBadTypeAdd(ref Web AretVal) {
            AretVal = new BadTypeAdd();
        }
        public static void RunBadTypeEdit(ref Web AretVal) {
            AretVal = new BadTypeEdit();
        }
        public static void RunBadTypeDelete(ref Web AretVal) {
            AretVal = new BadTypeDelete();
        }
    }
}