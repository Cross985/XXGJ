using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace Contractmenu
{
    /// <summary>
    /// 产品小类
    /// </summary>
    public class ProdType :Sage.CRM.WebObject.ListPage
    {
        public ProdType()
            : base("ProdType", "ProdTypeGrid", "ProdTypeFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "ptyp_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/ProdType.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>产品小类</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("ContractManagement", "ProdType");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "ProdType") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("ProdType", "RunDataPageNew") + "&J=ProdType&T=new");
            }
        }
    }

}

