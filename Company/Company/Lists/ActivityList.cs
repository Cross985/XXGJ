using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class ActivityList : ListPage
    {
        public ActivityList()
            : base("ActivityIncome", "ActivityIncomeGrid", "ActivityIncomeSearchBox")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "acin_deleted is null and acin_companyid=" + compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            AddUrlButton("New", "New.gif", UrlDotNet("ActivityIncome", "RunDataPageNew") + "&comp_companyid=" + compid);
            //base.AddNewButton();
        }
    }
}
