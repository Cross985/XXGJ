using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class CompRateList : ListPage
    {
        public CompRateList()
            : base("CompRate", "CompRateGrid", "CompRateSearchBox")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "cprt_deleted is null and cprt_companyid=" + compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            AddUrlButton("New", "New.gif", UrlDotNet("CompRate", "RunDataPageNew") + "&comp_companyid=" + compid);
            //base.AddNewButton();
        }
    }
}
