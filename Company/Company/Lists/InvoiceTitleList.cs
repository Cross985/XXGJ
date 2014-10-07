using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class InvoiceTitleList : ListPage
    {
        public InvoiceTitleList()
            : base("InvoiceTitle", "InvoiceTitleGrid", "InvoiceTitleSearchBox")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "inti_deleted is null and inti_companyid=" + compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            AddUrlButton("New", "New.gif", UrlDotNet("Company", "RunInvoiceAdd") + "&comp_companyid=" + compid);
            //base.AddNewButton();
        }
    }
}
