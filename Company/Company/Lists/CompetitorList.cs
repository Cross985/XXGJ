using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class CompetitorList : ListPage
    {
        public CompetitorList()
            : base("Competitor", "CompetitorGrid", "CompetitorSearchBox")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "cpet_deleted is null and cpet_companyid=" + compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            AddUrlButton("New", "New.gif", UrlDotNet("Competitor", "RunDataPageNew") + "&comp_companyid=" + compid);
            //base.AddNewButton();
        }
    }
}
