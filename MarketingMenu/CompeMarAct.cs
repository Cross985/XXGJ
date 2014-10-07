using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace MarketingMenu
{
    /// <summary>
    /// 竞争对手市场活动
    /// </summary>
    public class CompeMarAct :Sage.CRM.WebObject.ListPage
    {
        public CompeMarAct()
            : base("CompeMarAct", "CompeMarActGrid", "CompeMarActFilterBox")
        {
            this.ResultsGrid.RowsPerScreen = 50;
            this.ResultsGrid.Filter = "cmac_deleted is null";

        }

        public override void GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/CompeMarAct.gif' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><SPAN CLASS=TOPCAPTION>竞争对手市场活动</SPAN></td></tr></table>";
            AddTopContent(strTopContent);
            GetTabs("MarketingManagement", "CompeMarAct");            
        }

        public override void AddNewButton()
        {
            if (CurrentUser.HasRights(Sage.PermissionType.Insert, "CompeMarAct") || CurrentUser.IsAdmin())
            {
                AddUrlButton("New", "New.gif", UrlDotNet("CompeMarAct", "RunDataPageNew") + "&J=CompeMarAct&T=new");
            }
        }
    }

}

