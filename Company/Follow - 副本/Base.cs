using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Follow.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : Follow  
 * Created On: 2014/8/22 15:10:44
 * Created By: Steven
 * 
 ************************************/

namespace Follow
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new FollowSearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new FollowListPage();
        }

        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new FollowDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new FollowDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new FollowDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new FollowDataPageDelete();
        }
    }
}