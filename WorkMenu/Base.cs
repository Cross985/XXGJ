using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

/* ********************************
 * Simple Sage CRM 7.0 Application Extension 
 * 
 * Name: WorkMenu 
 * Created On: 8/27/2008 9:27:21 AM
 * Created By: Jeff Richards
 * 
 *********************************/

namespace WorkMenu {
    //static class AppFactory is REQUIRED!
    public static class AppFactory {

        public static void RunMonthPlan(ref Web AretVal) {
            AretVal = new MonthPlan();
        }

    }
}