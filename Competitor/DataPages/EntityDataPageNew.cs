using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Competitor.DataPages
{
    public class CompetitorDataPageNew : DataPageNew
    {
        public CompetitorDataPageNew()
            : base("Competitor", "cpet_competitorid", "CompetitorNewEntry")
        {
           // this.CancelButton = false;
            UseTabs = false;
        }

        public override void BuildContents()
        {
            try
            {

                /* Add your code here */
                AddTabHead("新建竞争对手");
                this.EntryGroups[0].Title = "Competitor";
                base.BuildContents();
               // AddUrlButton("Cancel", "cancel.gif", UrlDotNet(ThisDotNetDll, "RunListPage") );

            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}