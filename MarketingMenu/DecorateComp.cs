using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace MarketingMenu
{
    /// <summary>
    /// 装修公司
    /// </summary>
    public class DecorateComp :Sage.CRM.WebObject.ListPage
    {
        public DecorateComp()
            : base("DecorateComp", "DecorateCompGrid", "DecorateCompFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "dcom_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/DecorateComp.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>装修公司</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("MarketingManagement", "DecorateComp");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "DecorateComp") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("DecorateComp", "RunDataPageNew") + "&J=DecorateComp&T=new");
            }
        }
    }

}

