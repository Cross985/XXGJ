using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Competitor.DataPages;

/********************************************* 
 * Sage CRM Application Extension for Entity: 
 * 
 * Name      : Competitor  
 * Created On: 2012-12-24 10:03:35
 * Created By: Joyce
 * 
 ************************************/

namespace Competitor
{
    //REQURED - static class AppFactory is required!
    public static class AppFactory
    {
        public static void RunSearchPage(ref Web AretVal)
        {
            AretVal = new CompetitorSearchPage();
        }

        public static void RunListPage(ref Web AretVal)
        {
            AretVal = new CompetitorListPage();
        }


        public static void RunDataPage(ref Web AretVal)
        {
            AretVal = new CompetitorDataPage();
        }

        public static void RunDataPageEdit(ref Web AretVal)
        {
            AretVal = new CompetitorDataPageEdit();
        }

        public static void RunDataPageNew(ref Web AretVal)
        {
            AretVal = new CompetitorDataPageNew();
        }

        public static void RunDataPageDelete(ref Web AretVal)
        {
            AretVal = new CompetitorDataPageDelete();
        }
        public static void RunCpetProductSummary(ref Web AretVal)
        {
            AretVal = new CpetProductSummary();
        }
        public static void RunCpetProductAdd(ref Web AretVal)
        {
            AretVal = new CpetProductAdd();
        }
        public static void RunCpetProductEdit(ref Web AretVal)
        {
            AretVal = new CpetProductEdit();
        }
        public static void RunCpetProductDelete(ref Web AretVal)
        {
            AretVal = new CpetProductDelete();
        }
        public static void RunMarketActivitySummary(ref Web AretVal) {
            AretVal = new MarketActivitySummary();
        }
        public static void RunMarketActivityAdd(ref Web AretVal) {
            AretVal = new MarketActivityAdd();
        }
        public static void RunMarketActivityEdit(ref Web AretVal) {
            AretVal = new MarketActivityEdit();
        }
        public static void RunMarketActivityDelete(ref Web AretVal) {
            AretVal = new MarketActivityDelete();
        }
        public static void RunPersonSummary(ref Web AretVal) {
            AretVal = new PersonSummary();
        }
        public static void RunPersonAdd(ref Web AretVal) {
            AretVal = new PersonAdd();
        }
        public static void RunPersonEdit(ref Web AretVal) {
            AretVal = new PersonEdit();
        }
        public static void RunPersonDelete(ref Web AretVal) {
            AretVal = new PersonDelete();
        }
    }
}