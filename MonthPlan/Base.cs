using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using MonthPlan.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : MonthPlan  
 * Created On: 2014/8/8 17:54:19
 * Created By: thinkpad
 * 
 ************************************/

namespace MonthPlan {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new MonthPlanSearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new MonthPlanListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new MonthPlanDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new MonthPlanDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new MonthPlanDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new MonthPlanDataPageDelete();
        }

        public static void RunVisitComponySummary(ref Web AretVal) {
            AretVal = new VisitComponySummary();
        }
        public static void RunVisitComponyAdd(ref Web AretVal) {
            AretVal = new VisitComponyAdd();
        }
        public static void RunVisitComponyEdit(ref Web AretVal) {
            AretVal = new VisitComponyEdit();
        }
        public static void RunVisitComponyDelete(ref Web AretVal) {
            AretVal = new VisitComponyDelete();
        }
        public static void RunPlanDetailSummary(ref Web AretVal) {
            AretVal = new PlanDetailSummary();
        }
        public static void RunPlanDetailAdd(ref Web AretVal) {
            AretVal = new PlanDetailAdd();
        }
        public static void RunPlanDetailEdit(ref Web AretVal) {
            AretVal = new PlanDetailEdit();
        }
        public static void RunPlanDetailDelete(ref Web AretVal) {
            AretVal = new PlanDetailDelete();
        }
        public static void RunSalePlanDetailSummary(ref Web AretVal) {
            AretVal = new SalePlanDetailSummary();
        }
        public static void RunSalePlanDetailAdd(ref Web AretVal) {
            AretVal = new SalePlanDetailAdd();
        }
        public static void RunSalePlanDetailEdit(ref Web AretVal) {
            AretVal = new SalePlanDetailEdit();
        }
        public static void RunSalePlanDetailDelete(ref Web AretVal) {
            AretVal = new SalePlanDetailDelete();
        }
        public static void RunDealerDetailSummary(ref Web AretVal) {
            AretVal = new DealerDetailSummary();
        }
        public static void RunDealerDetailAdd(ref Web AretVal) {
            AretVal = new DealerDetailAdd();
        }
        public static void RunDealerDetailEdit(ref Web AretVal) {
            AretVal = new DealerDetailEdit();
        }
        public static void RunDealerDetailDelete(ref Web AretVal) {
            AretVal = new DealerDetailDelete();
        }
        public static void RunProcessMethodSummary(ref Web AretVal) {
            AretVal = new ProcessMethodSummary();
        }
        public static void RunProcessMethodAdd(ref Web AretVal) {
            AretVal = new ProcessMethodAdd();
        }
        public static void RunProcessMethodEdit(ref Web AretVal) {
            AretVal = new ProcessMethodEdit();
        }
        public static void RunProcessMethodDelete(ref Web AretVal) {
            AretVal = new ProcessMethodDelete();
        }
    }
}