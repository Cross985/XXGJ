using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

/* ********************************
 * Simple Sage CRM 7.0 Application Extension 
 * 
 * Name: SalesMenu 
 * Created On: 8/27/2008 9:27:21 AM
 * Created By: Jeff Richards
 * 
 *********************************/

namespace SalesMenu {
    //static class AppFactory is REQUIRED!
    public static class AppFactory {

        public static void RunOpportunity(ref Web AretVal) {
            AretVal = new Opportunity();
        }
        public static void RunOppoCompetitor(ref Web AretVal) {
            AretVal = new OppoCompetitor();
        }

    }
}