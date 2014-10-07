using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace ServiceAccept
{
    public class ServiceDealDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("sede_ServiceDealid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record ServiceDeal = FindRecord("ServiceDeal", "sede_ServiceDealid=" + id);
                string sede_serviceacceptid = ServiceDeal.GetFieldAsString("sede_serviceacceptid");
                EntryGroup ServiceDealNewEntry = new EntryGroup("ServiceDealNewEntry");
                ServiceDealNewEntry.Fill(ServiceDeal);

                AddTabHead("Delete ServiceDeal");
                if (hMode == "Delete")
                {
                    ServiceDeal.DeleteRecord = true;
                    ServiceDeal.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + sede_serviceacceptid + "&J=Summary";
                    url = url.Replace("Key37", "ServiceDealid");
                    url = url + "&Key37=" + sede_serviceacceptid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    ServiceDealNewEntry.GetHtmlInViewMode(ServiceDeal);
                    vpMainPanel.Add(ServiceDealNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + sede_serviceacceptid + "&J=Summary";
                    url = url.Replace("Key37", "ServiceDealid");
                    url = url + "&Key37=" + sede_serviceacceptid;
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            }
            catch (Exception e)
            {
                AddError(e.Message);
            }
        }
    }
}
