using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace WorkMenu
{
    /// <summary>
    /// 工作计划
    /// </summary>
    public class MonthPlan :Sage.CRM.WebObject.ListPage
    {
        public MonthPlan()
            : base("MonthPlan", "MonthPlanGrid", "MonthPlanFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "mopl_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/MonthPlan.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>工作计划</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("User", "MonthPlan");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "MonthPlan") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("MonthPlan", "RunDataPageNew") + "&J=MonthPlan&T=new");
            }
        }
    }

}

