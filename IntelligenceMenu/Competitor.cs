using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace IntelligenceMenu
{
    /// <summary>
    /// 竞争对手
    /// </summary>
    public class Competitor :Sage.CRM.WebObject.ListPage
    {
        public Competitor()
            : base("Competitor", "CompetitorGrid", "CompetitorFilter")
        {
            this.ResultsGrid.RowsPerScreen = 30;
            this.ResultsGrid.Filter = "cpet_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/Competitor.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>竞争对手</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("CompanyMangement", "Competitor");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "Competitor") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("Competitor", "RunDataPageNew") + "&J=Competitor&T=new");
            }
        }
    }

}

