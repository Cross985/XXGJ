using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Equipment.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : Equipment  
 * Created On: 2014/8/8 16:35:28
 * Created By: thinkpad
 * 
 ************************************/

namespace Equipment {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new EquipmentSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new EquipmentListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new EquipmentDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new EquipmentDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new EquipmentDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new EquipmentDataPageDelete();
        }
    }
}