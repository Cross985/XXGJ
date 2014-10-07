using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MarketInfo.DataPages
{
    public class MarketInfoSearchPage : SearchPage
    {
        public MarketInfoSearchPage()
            : base("MarketInfoSearchBox", "MarketInfoGrid")
        {
        }
    }
}