using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace Competitor
{
    public class CpetProductEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string cppr_CpetProductid = Dispatch.EitherField("cppr_CpetProductid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record CpetProduct = FindRecord("CpetProduct", "cppr_CpetProductid=" + cppr_CpetProductid);
                string cpet_competitorid = CpetProduct.GetFieldAsString("cppr_competitorid");
                EntryGroup CpetProductNewEntry = new EntryGroup("CpetProductNewEntry");
                CpetProductNewEntry.Fill(CpetProduct);
                Entry IntentionOrderidEntry = CpetProductNewEntry.GetEntry("cppr_competitorid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("CpetProduct");
                GetTabs("CpetProduct", "CpetProduct Summary");
                if (hMode == "Save")
                {

                    ////double original =CpetProduct.GetFieldAsDouble("");		    
                    CpetProductNewEntry.Fill(CpetProduct);
                    ////double  =CpetProduct.GetFieldAsDouble("");

                    if (CpetProductNewEntry.Validate())
                    {
                        CpetProduct.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                        url = url.Replace("Key37", "CpetProductid");
                        url = url + "&Key37=" + cpet_competitorid;
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
                    CpetProductNewEntry.GetHtmlInEditMode(CpetProduct);
                    vpMainPanel.Add(CpetProductNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunCpetProductDelete") + "&cppr_CpetProductid=" + cppr_CpetProductid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
