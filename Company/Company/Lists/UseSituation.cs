using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class UseSituationList : ListPage
    {
        public UseSituationList()
            : base("UseSituation", "UseSituationGrid", "UseSituationSearchBox")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "usst_deleted is null and usst_companyid=" + compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            AddUrlButton("New", "New.gif", UrlDotNet(ThisDotNetDll, "RunUSAdd") + "&comp_companyid=" + compid);
            //base.AddNewButton();
        }
    }
}
