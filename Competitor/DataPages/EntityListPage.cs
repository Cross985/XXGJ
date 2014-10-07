using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Competitor.DataPages
{
    public class CompetitorListPage : ListPage
    {
        public CompetitorListPage()
            : base("Competitor", "CompetitorGrid", "CompetitorFilter")
        {
            //FilterByField = "";
            //FilterByContextId = (int)Sage.KeyList.UserId;
            //string comp_companyid = Dispatch.EitherField("Key1");
            //this.ResultsGrid.RowsPerScreen = 25;
            //this.ResultsGrid.Filter = "opco_competitorid=" + comp_companyid;

        }

        public override void BuildContents()
        {
            try
            {

                /* Add your code here */

                base.BuildContents();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
        public override void AddNewButton() {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "Competitor")) {
                AddUrlButton("New", "New.gif", UrlDotNet("Competitor", "RunDataPageNew"));
            }
        }
    }
}