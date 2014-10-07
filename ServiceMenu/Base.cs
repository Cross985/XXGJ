using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

/* ********************************
 * Simple Sage CRM 7.0 Application Extension 
 * 
 * Name: ServiceMenu 客户服务菜单
 * Created On: 8/27/2008 9:27:21 AM
 * Created By: Jeff Richards
 * 
 *********************************/

namespace ServiceMenu
{
    //static class AppFactory is REQUIRED!
    public static class AppFactory
    {
        /// <summary>
        /// 客户服务单
        /// </summary>
        /// <param name="AretVal"></param>
        public static void RunCustomerService(ref Web AretVal)
        {
            AretVal = new Service();
        }
        /// <summary>
        /// 设备信息
        /// </summary>
        /// <param name="AretVal"></param>
        public static void RunEquipment(ref Web AretVal) {
            AretVal = new Equipment();
        }
        /// <summary>
        /// 维修服务单
        /// </summary>
        /// <param name="AretVal"></param>
        public static void RunMaintenance(ref Web AretVal) {
            AretVal = new Maintenance();
        }


    }
}