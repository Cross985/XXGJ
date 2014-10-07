using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MarketInfo.DataPages
{
    public class MarketInfoDataPageEdit : DataPageEdit
    {
        public MarketInfoDataPageEdit()
            : base("MarketInfo", "maif_MarketInfoId", "MarketInfoNewEntry")
        {
            this.CancelMethod = "RunDataPage";
        }

        public override void BuildContents()
        {
            try
            {

                /* Add your code here */
                this.EntryGroups[0].Title = "MarketInfo";
                base.BuildContents();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }

    }
}