using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

/* ********************************
 * Simple Sage CRM 7.0 Application Extension 
 * 
 * Name: IntelligenceMenu 
 * Created On: 8/27/2008 9:27:21 AM
 * Created By: Jeff Richards
 * 
 *********************************/

namespace IntelligenceMenu {
    //static class AppFactory is REQUIRED!
    public static class AppFactory {

        public static void RunCompetitor(ref Web AretVal) {
            AretVal = new Competitor();
        }
        public static void RunMarketInfo(ref Web AretVal) {
            AretVal = new MarketInfo();
        }

    }
}