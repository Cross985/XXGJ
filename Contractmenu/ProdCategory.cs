using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace Contractmenu
{
    /// <summary>
    /// 产品大类
    /// </summary>
    public class ProdCategory :Sage.CRM.WebObject.ListPage
    {
        public ProdCategory()
            : base("ProdCategory", "ProdCategoryGrid", "ProdCategoryFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "pcat_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/ProdCategory.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>产品大类</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("ContractManagement", "ProdCategory");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "ProdCategory") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("ProdCategory", "RunDataPageNew") + "&J=ProdCategory&T=new");
            }
        }
    }

}

