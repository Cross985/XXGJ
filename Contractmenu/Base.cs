using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

/* ********************************
 * Simple Sage CRM 7.0 Application Extension 
 * 
 * Name: Contractmenu 
 * Created On: 8/27/2008 9:27:21 AM
 * Created By: Jeff Richards
 * 
 *********************************/

namespace Contractmenu {
    //static class AppFactory is REQUIRED!
    public static class AppFactory {

        public static void RunProdCategory(ref Web AretVal) {
            AretVal = new ProdCategory();
        }
        public static void RunContract(ref Web AretVal) {
            AretVal = new Contract();
        }
        public static void RunProdType(ref Web AretVal) {
            AretVal = new ProdType();
        }

    }
}