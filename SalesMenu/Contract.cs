using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace Contractmenu
{
    /// <summary>
    /// 合同
    /// </summary>
    public class Contract :Sage.CRM.WebObject.ListPage
    {
        public Contract()
            : base("Contract", "ContractGrid", "ContractFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "cont_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/Contract.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>合同</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("SalesManagement", "Contract");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "Contract") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("Contract", "RunDataPageNew") + "&J=Contract&T=new");
            }
        }
    }

}

