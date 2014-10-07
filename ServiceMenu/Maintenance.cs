using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace ServiceMenu
{
    /// <summary>
    /// 维修受理单
    /// </summary>
    public class Maintenance :Sage.CRM.WebObject.ListPage
    {
        public Maintenance()
            : base("Maintenance", "MaintenanceGrid", "MaintenanceFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "mate_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/Maintenance.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>设备信息</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("ServiceManagement", "Maintenance");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "Maintenance") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("Maintenance", "RunDataPageNew") + "&J=Maintenance&T=new");
            }
        }
    }

}

