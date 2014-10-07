using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MarketInfo.DataPages
{
    public class MarketInfoDataPageDelete : DataPageDelete
    {
        public MarketInfoDataPageDelete()
            : base("MarketInfo", "maif_MarketInfoId", "MarketInfoNewEntry")
        {
            this.EntryGroups[0].Title = "MarketInfo";
            this.CancelMethod = "RunDataPage";
        }
    }
}