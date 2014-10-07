using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace ServiceAccept
{
    public class ServiceDealEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string sede_ServiceDealid = Dispatch.EitherField("sede_ServiceDealid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record ServiceDeal = FindRecord("ServiceDeal", "sede_ServiceDealid=" + sede_ServiceDealid);
                string sede_serviceacceptid = ServiceDeal.GetFieldAsString("sede_serviceacceptid");
                EntryGroup ServiceDealNewEntry = new EntryGroup("ServiceDealNewEntry");
                ServiceDealNewEntry.Fill(ServiceDeal);
                Entry IntentionOrderidEntry = ServiceDealNewEntry.GetEntry("sede_serviceacceptid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("ServiceDeal");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    ServiceDealNewEntry.Fill(ServiceDeal);
                    ////double  =Person.GetFieldAsDouble("");

                    if (ServiceDealNewEntry.Validate())
                    {
                        ServiceDeal.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + sede_serviceacceptid + "&J=Summary";
                        url = url.Replace("Key37", "ServiceDealid");
                        url = url + "&Key37=" + sede_serviceacceptid;
                        Dispatch.Redirect(url);
                        errorflag = -1;
                    }
                    else
                    {
                        errorflag = 1;
                    }

                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    ServiceDealNewEntry.GetHtmlInEditMode(ServiceDeal);
                    vpMainPanel.Add(ServiceDealNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunServiceDealDelete") + "&sede_ServiceDealid=" + sede_ServiceDealid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
