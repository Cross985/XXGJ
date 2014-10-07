using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Competitor
{
    public class CpetProductDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("cppr_CpetProductid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record CpetProduct = FindRecord("CpetProduct", "cppr_CpetProductid=" + id);
                string cpet_competitorid = CpetProduct.GetFieldAsString("cppr_competitorid");
                EntryGroup CpetProductNewEntry = new EntryGroup("CpetProductNewEntry");
                CpetProductNewEntry.Fill(CpetProduct);

                AddTabHead("Delete CpetProduct");
                if (hMode == "Delete")
                {
                    CpetProduct.DeleteRecord = true;
                    CpetProduct.SaveChanges();

                    ////double  =CpetProduct.GetFieldAsDouble("");
                    ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                    ////double  = BusReport.GetFieldAsDouble("");                        
                    //// =  - ;
                    ////BusReport.SetField("", );
                    ////BusReport.SaveChanges();

                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                    url = url.Replace("Key37", "CpetProductid");
                    url = url + "&Key37=" + cpet_competitorid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    CpetProductNewEntry.GetHtmlInViewMode(CpetProduct);
                    vpMainPanel.Add(CpetProductNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                    url = url.Replace("Key37", "CpetProductid");
                    url = url + "&Key37=" + cpet_competitorid;
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
