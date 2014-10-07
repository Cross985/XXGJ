using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace ServiceMenu
{
    /// <summary>
    /// 设备信息
    /// </summary>
    public class Equipment :Sage.CRM.WebObject.ListPage
    {
        public Equipment()
            : base("Equipment", "EquipmentGrid", "EquipmentFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "equi_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/Equipment.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>设备信息</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("ServiceManagement", "Equipment");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "Equipment") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("Equipment", "RunDataPageNew") + "&J=Equipment&T=new");
            }
        }
    }

}

