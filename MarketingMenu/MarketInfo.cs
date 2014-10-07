using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace MarketingMenu
{
    /// <summary>
    /// 市场情报
    /// </summary>
    public class MarketInfo :Sage.CRM.WebObject.ListPage
    {
        public MarketInfo()
            : base("MarketInfo", "MarketInfoGrid", "MarketInfoFilter")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "maif_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/MarketInfo.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>市场情报</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("MarketingManagement", "MarketInfo");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "MarketInfo") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("MarketInfo", "RunDataPageNew") + "&J=MarketInfo&T=new");
            }
        }
    }

}

