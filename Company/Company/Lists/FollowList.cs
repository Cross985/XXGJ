using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class FollowList:ListPage
    {
        public FollowList()
            : base("Follow", "FollowGrid", "FollowSearchBox")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "foll_deleted is null and foll_companyid="+compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            AddUrlButton("New","New.gif",UrlDotNet("Follow","RunDataPageNew")+"&comp_companyid=" + compid  );
            //base.AddNewButton();
        }
    }
}
