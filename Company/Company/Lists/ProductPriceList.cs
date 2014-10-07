using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class ProdPriceList : ListPage
    {
        public ProdPriceList()
            : base("ProductPrice", "ProductPriceGrid", "ProductPriceSearchBox")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "prpi_deleted is null and prpi_companyid=" + compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            AddUrlButton("New", "New.gif", UrlDotNet("ProductPrice", "RunDataPageNew") + "&comp_companyid=" + compid);
        }
    }
}
