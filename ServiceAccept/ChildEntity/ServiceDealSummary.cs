using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace ServiceAccept
{
    public class ServiceDealSummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("ServiceDeal", "Summary");
            AddTopContent(GetCustomEntityTopFrame("ServiceDeal"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string sede_ServiceDealid = Dispatch.EitherField("sede_ServiceDealid");

                Record ServiceDeal = FindRecord("ServiceDeal", "sede_ServiceDealid=" + sede_ServiceDealid);
                string sede_serviceacceptid = ServiceDeal.GetFieldAsString("sede_serviceacceptid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunServiceDealEdit") + "&sede_ServiceDealid=" + sede_ServiceDealid;
                    Dispatch.Redirect(urledit);


                    EntryGroup ServiceDealNewEntry = new EntryGroup("ServiceDealNewEntry");

                ServiceDealNewEntry.Title = "ServiceDeal";
                ServiceDealNewEntry.Fill(ServiceDeal);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(ServiceDealNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunServiceDealDelete") + "&sede_ServiceDealid=" + sede_ServiceDealid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + sede_serviceacceptid;
                    url = url.Replace("Key37", "ServiceDealid");
                url = url + "&Key37=" + sede_serviceacceptid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}