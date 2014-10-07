using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using MarActPlan.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : MarActPlan  
 * Created On: 2014/8/8 15:12:48
 * Created By: thinkpad
 * 
 ************************************/

namespace MarActPlan {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new MarActPlanSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new MarActPlanListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new MarActPlanDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new MarActPlanDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new MarActPlanDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new MarActPlanDataPageDelete();
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
        public static void RunDisplayContentSummary(ref Web AretVal) {
            AretVal = new DisplayContentSummary();
        }
        public static void RunDisplayContentAdd(ref Web AretVal) {
            AretVal = new DisplayContentAdd();
        }
        public static void RunDisplayContentEdit(ref Web AretVal) {
            AretVal = new DisplayContentEdit();
        }
        public static void RunDisplayContentDelete(ref Web AretVal) {
            AretVal = new DisplayContentDelete();
        }
        public static void RunActualCostSummary(ref Web AretVal) {
            AretVal = new ActualCostSummary();
        }
        public static void RunActualCostAdd(ref Web AretVal) {
            AretVal = new ActualCostAdd();
        }
        public static void RunActualCostEdit(ref Web AretVal) {
            AretVal = new ActualCostEdit();
        }
        public static void RunActualCostDelete(ref Web AretVal) {
            AretVal = new ActualCostDelete();
        }
    }
}