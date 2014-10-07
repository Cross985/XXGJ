using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Port.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : Port  
 * Created On: 2014/8/22 15:10:44
 * Created By: Steven
 * 
 ************************************/

namespace Port
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new PortSearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new PortListPage();
        }

        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new PortDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new PortDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new PortDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new PortDataPageDelete();
        }
    }
}