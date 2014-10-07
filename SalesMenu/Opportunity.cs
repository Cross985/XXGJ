using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace SalesMenu
{
    /// <summary>
    /// 机会
    /// </summary>
    public class Opportunity :Sage.CRM.WebObject.ListPage
    {
        public Opportunity()
            : base("Opportunity", "OpportunityGrid", "OpportunityFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "oppo_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/Opportunity.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>机会</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("SalesManagement", "Opportunity");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "Opportunity") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", Url("1190"));
            }
        }
    }

}

