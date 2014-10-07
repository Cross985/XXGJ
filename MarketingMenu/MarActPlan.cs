using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace MarketingMenu
{
    /// <summary>
    /// 市场活动
    /// </summary>
    public class MarActPlan :Sage.CRM.WebObject.ListPage
    {
        public MarActPlan()
            : base("MarActPlan", "MarActPlanGrid", "MarActPlanFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "mapl_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/MarActPlan.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>市场活动</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("MarketingManagement", "MarActPlan");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "MarActPlan") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("MarActPlan", "RunDataPageNew") + "&J=MarActPlan&T=new");
            }
        }
    }

}

