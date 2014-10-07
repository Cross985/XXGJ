using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Company.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : Company  
 * Created On: 2014/7/11 9:33:23
 * Created By: Steven
 * 
 ************************************/

namespace Company
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new CompanySearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new CompanyListPage();
        }

        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new CompanyDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new CompanyDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new CompanyDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new CompanyDataPageDelete();
        }
        public static void RunUSAdd(ref Web AretVal)
        {
            AretVal = new USAdd();
        }
        public static void RunUSEdit(ref Web AretVal)
        {
            AretVal = new USEdit();
        }
        public static void RunUSDelete(ref Web AretVal)
        {
            AretVal = new UseSituationDelete();
        }
        public static void RunOppoList(ref Web AretVal)
        {
            AretVal = new Opportunity();
        }
        public static void RunAddressEdit(ref Web AretVal)
        {
            AretVal = new AddressEdit();
        }
        public static void RunAddressAdd(ref Web AretVal)
        {
            AretVal = new AddressAdd();
        }
        public static void RunAddressDelete(ref Web AretVal)
        {
            AretVal = new AddressDelete();
        }
        public static void RunInvoiceEdit(ref Web AretVal)
        {
            AretVal = new InvoiceEdit();
        }
        public static void RunInvoiceAdd(ref Web AretVal)
        {
            AretVal = new InvoiceAdd();
        }
        public static void RunInvoiceDelete(ref Web AretVal)
        {
            AretVal = new InvoiceDelete();
        }
        public static void RunFollowList(ref Web AretVal)
        {
            AretVal = new FollowList();
        }
        public static void RunProductList(ref Web AretVal)
        {
            AretVal = new ProdList();
        }
        public static void RunProductPriceList(ref Web AretVal)
        {
            AretVal = new ProdPriceList();
        }
        public static void RunActivityList(ref Web AretVal)
        {
            AretVal = new ActivityList(); 
        }
        public static void RunPortList(ref Web AretVal)
        {
            AretVal = new PortList();
        }
        public static void RunCompRateList(ref Web AretVal)
        {
            AretVal = new CompRateList(); 
        }
        public static void RunUSList(ref Web AretVal)
        {
            AretVal = new UseSituationList();
        }
        public static void RunAddressList(ref Web AretVal)
        {
            AretVal = new AddressList();
        }
        public static void RunInvoiceTitleList(ref Web AretVal)
        {
            AretVal = new InvoiceTitleList();
        }
        public static void RunCompetitorList(ref Web AretVal)
        {
            AretVal = new CompetitorList();
        }
        public static void RunFollowMenuList(ref Web AretVal)
        {
            AretVal = new FollowMenuList();
        }
    }
}