using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

/* ********************************
 * Simple Sage CRM 7.0 Application Extension 
 * 
 * Name: MarketingMenu 
 * Created On: 8/27/2008 9:27:21 AM
 * Created By: Jeff Richards
 * 
 *********************************/

namespace MarketingMenu {
    //static class AppFactory is REQUIRED!
    public static class AppFactory {

        public static void RunDecorateComp(ref Web AretVal) {
            AretVal = new DecorateComp();
        }
        public static void RunMarActPool(ref Web AretVal) {
            AretVal = new MarActPool();
        }
        public static void RunMarActPlan(ref Web AretVal) {
            AretVal = new MarActPlan();
        }
        public static void RunCompeMarAct(ref Web AretVal) {
            AretVal = new CompeMarAct();
        }
        public static void RunMarketInfo(ref Web AretVal)
        {
            AretVal = new MarketInfo();
        }

    }
}