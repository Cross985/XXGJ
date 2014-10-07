using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MarketInfo.DataPages
{
    public class MarketInfoListPage : ListPage
    {
        public MarketInfoListPage()
            : base("MarketInfo", "MarketInfoGrid", "MarketInfoFilter")
        {

        }

        public override void BuildContents()
        {
            try
            {
                base.BuildContents();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
        public override void AddNewButton()
        {
            AddUrlButton("New", "New.gif", UrlDotNet(ThisDotNetDll, "RunDataPageNew") + "&J=MarketInfo&T=new");
        }

    }
}