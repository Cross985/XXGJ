using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class FollowMenuList : ListPage
    {
        public FollowMenuList()
            : base("Follow", "FollowGrid", "FollowSearchBox")
        {
            //string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.RowsPerScreen = 30;
            this.ResultsGrid.Filter = "foll_deleted is null";
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            //string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            //AddUrlButton("New", "New.gif", UrlDotNet("Follow", "RunDataPageNew"));
            //base.AddNewButton();
        }
    }
}
