using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace ServiceMenu
{
    /// <summary>
    /// 服务受理单
    /// </summary>
    public class Service :Sage.CRM.WebObject.ListPage
    {
        public Service()
            : base("ServiceAccept", "ServiceAcceptGrid", "ServiceAcceptFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "seac_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/ServiceAccept.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>服务受理单</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("ServiceManagement", "ServiceAccept");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "ServiceAccept") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("ServiceAccept", "RunDataPageNew") + "&J=ServiceAccept&T=new");
            }
        }
    }

}

