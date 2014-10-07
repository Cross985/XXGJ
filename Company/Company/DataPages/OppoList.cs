using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace Company.DataPages
{
    /// <summary>
    /// 机会
    /// </summary>
    public class Opportunity : Sage.CRM.WebObject.ListPage
    {
        public Opportunity()
            : base("Opportunity", "OpportunityGrid", "OpportunityFilterBox")
        {
            string compid = Dispatch.EitherField("key1");
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "oppo_deleted is null and Oppo_PrimaryCompanyId=" + compid;

        }

        //public override void GetTabs()
        //{
        //    string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/Opportunity.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>机会</SPAN></td></tr></table>";
        //    AddTopContent(strTopContent);
        //    GetTabs("CompanySummary", "OpportunityList");
        //}

        public override void AddNewButton()
        {
            
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "Opportunity") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", Url("1190"));
            }
        }
    }

}

