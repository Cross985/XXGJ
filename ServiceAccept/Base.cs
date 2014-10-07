using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using ServiceAccept.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : ServiceAccept  
 * Created On: 2014/8/8 16:42:20
 * Created By: thinkpad
 * 
 ************************************/

namespace ServiceAccept {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new ServiceAcceptSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new ServiceAcceptListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new ServiceAcceptDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new ServiceAcceptDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new ServiceAcceptDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new ServiceAcceptDataPageDelete();
        }
        public static void RunCusUseStatusSummary(ref Web AretVal) {
            AretVal = new CusUseStatusSummary();
        }
        public static void RunCusUseStatusAdd(ref Web AretVal) {
            AretVal = new CusUseStatusAdd();
        }
        public static void RunCusUseStatusEdit(ref Web AretVal) {
            AretVal = new CusUseStatusEdit();
        }
        public static void RunCusUseStatusDelete(ref Web AretVal) {
            AretVal = new CusUseStatusDelete();
        }
        public static void RunServiceDealSummary(ref Web AretVal) {
            AretVal = new ServiceDealSummary();
        }
        public static void RunServiceDealAdd(ref Web AretVal) {
            AretVal = new ServiceDealAdd();
        }
        public static void RunServiceDealEdit(ref Web AretVal) {
            AretVal = new ServiceDealEdit();
        }
        public static void RunServiceDealDelete(ref Web AretVal) {
            AretVal = new ServiceDealDelete();
        }
    }
}