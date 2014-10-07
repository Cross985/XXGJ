using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using ProdCategory.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : ProdCategory  
 * Created On: 2014/8/8 9:59:35
 * Created By: thinkpad
 * 
 ************************************/

namespace ProdCategory {
    //REQURED - static class AppFactory is required!
    public static class AppFactory {
        public static void RunSearchPage(ref Web AretVal) {
            AretVal = new ProdCategorySearchPage();
        }

        public static void RunListPage(ref Web AretVal) {
            AretVal = new ProdCategoryListPage();
        }

        public static void RunDataPage(ref Web AretVal) {
            AretVal = new ProdCategoryDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal) {
            AretVal = new ProdCategoryDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal) {
            AretVal = new ProdCategoryDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal) {
            AretVal = new ProdCategoryDataPageDelete();
        }
    }
}