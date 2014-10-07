using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace ServiceAccept
{
    public class ServiceDealAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string seac_ServiceAcceptId = Dispatch.EitherField("seac_ServiceAcceptId");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup ServiceDealNewEntry = new EntryGroup("ServiceDealNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry bred_busreportidEntry = ServiceDealNewEntry.GetEntry("sede_serviceacceptid");
                if (bred_busreportidEntry != null)
                {
                    bred_busreportidEntry.DefaultValue = seac_ServiceAcceptId;
                    bred_busreportidEntry.ReadOnly = true;
                }

                AddTabHead("ServiceDeal");
                if (hMode == "Save")
                {
                    Record ServiceDeal = new Record("ServiceDeal");
                    ServiceDealNewEntry.Fill(ServiceDeal);
                    if (ServiceDealNewEntry.Validate())
                    {
                        ServiceDeal.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + seac_ServiceAcceptId + "&J=Summary";
                        url = url.Replace("Key37", "DecorateCompid");
                        url = url + "&Key37=" + seac_ServiceAcceptId;
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
                    if (errorflag == 2)
                    {
                        AddError(errormessage);
                    }

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    ServiceDealNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(ServiceDealNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + seac_ServiceAcceptId + "&J=Summary";
                    url = url.Replace("Key37", "ServiceDealid");
                    url = url + "&Key37=" + seac_ServiceAcceptId;
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
