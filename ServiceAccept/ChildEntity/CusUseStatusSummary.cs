using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace ServiceAccept
{
    public class CusUseStatusSummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("CusUseStatus", "Summary");
            AddTopContent(GetCustomEntityTopFrame("CusUseStatus"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string cust_cususestatusid = Dispatch.EitherField("cust_cususestatusid");

                Record CusUseStatus = FindRecord("CusUseStatus", "cust_cususestatusid=" + cust_cususestatusid);
                string cust_serviceacceptid = CusUseStatus.GetFieldAsString("cust_serviceacceptid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunCusUseStatusEdit") + "&cust_cususestatusid=" + cust_cususestatusid;
                    Dispatch.Redirect(urledit);


                    EntryGroup CusUseStatusNewEntry = new EntryGroup("CusUseStatusNewEntry");

                CusUseStatusNewEntry.Title = "CusUseStatus";
                CusUseStatusNewEntry.Fill(CusUseStatus);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(CusUseStatusNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunCusUseStatusDelete") + "&cust_cususestatusid=" + cust_cususestatusid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + cust_serviceacceptid;
                    url = url.Replace("Key37", "CusUseStatusid");
                url = url + "&Key37=" + cust_serviceacceptid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}