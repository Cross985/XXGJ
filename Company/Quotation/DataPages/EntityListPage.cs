using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Quotation.DataPages
{
    public class QuotationListPage : ListPage
    {
        public QuotationListPage()
            : base("Quotation", "QuotationGrid", "QuotationSearchBox")
        {
            //FilterByField = "";
            //FilterByContextId = (int)Sage.KeyList.UserId;
            string oppoid = Dispatch.EitherField("oppo_opportunityid");
            if (string.IsNullOrEmpty(oppoid))
                oppoid = Dispatch.EitherField("key7");
            this.ResultsGrid.Filter = "quta_deleted is null and quta_opportunityid="+oppoid;

        }

        public override void BuildContents()
        {
            try
            {
                //this.UseEntityTabs = false;
                //this.GetTabs("User","QuotationList");
                /* Add your code here */

                base.BuildContents();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
        public override void AddNewButton()
        {
            string oppoid = Dispatch.EitherField("key7");
            AddUrlButton("New", "New.gif", UrlDotNet(ThisDotNetDll, "RunDataPageNew") + "&oppo_OpportunityId=" + oppoid + "&J=Quotation&T=Opportunity");
            //base.AddNewButton();
        }
    }
}