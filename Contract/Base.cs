using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Contract.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : Contract  
 * Created On: 2012/3/25 22:53:08
 * Created By: Administrator
 * 
 ************************************/

namespace Contract
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new ContractSearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new ContractListPage();
        }

        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new ContractDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new ContractDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new ContractDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new ContractDataPageDelete();
        }

        public static void RunContractDetailSummary(ref Web AretVal)
        {
            AretVal = new ContractDetailSummary();
        }
        public static void RunContractDetailAdd(ref Web AretVal)
        {
            AretVal = new ContractDetailAdd();
        }
        public static void RunContractDetailEdit(ref Web AretVal)
        {
            AretVal = new ContractDetailEdit();
        }
        public static void RunContractDetailDelete(ref Web AretVal)
        {
            AretVal = new ContractDetailDelete();
        }
    }
}