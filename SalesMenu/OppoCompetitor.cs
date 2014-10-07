using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace SalesMenu
{
    /// <summary>
    /// 销售机会竞争对手
    /// </summary>
    public class OppoCompetitor :Sage.CRM.WebObject.ListPage
    {
        public OppoCompetitor()
            : base("OppoCompetitor", "OppoCompetitorGrid", "OppoCompetitorFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "opco_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/OppoCompetitor.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>销售机会竞争对手</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("SalesManagement", "OppoCompetitor");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "OppoCompetitor") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("OppoCompetitor", "RunDataPageNew") + "&J=OppoCompetitor&T=new");
            }
        }
    }

}

