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
    public class MarketActivityEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string mact_MarketActivityid = Dispatch.EitherField("mact_MarketActivityid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record MarketActivity = FindRecord("MarketActivity", "mact_MarketActivityid=" + mact_MarketActivityid);
                string cpet_competitorid = MarketActivity.GetFieldAsString("mact_competitorid");
                EntryGroup MarketActivityNewEntry = new EntryGroup("MarketActivityNewEntry");
                MarketActivityNewEntry.Fill(MarketActivity);
                Entry IntentionOrderidEntry = MarketActivityNewEntry.GetEntry("mact_competitorid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("MarketActivity");
                GetTabs("MarketActivity", "MarketActivity Summary");
                if (hMode == "Save")
                {

                    ////double original =MarketActivity.GetFieldAsDouble("");		    
                    MarketActivityNewEntry.Fill(MarketActivity);
                    ////double  =MarketActivity.GetFieldAsDouble("");

                    if (MarketActivityNewEntry.Validate())
                    {
                        MarketActivity.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                        url = url.Replace("Key37", "MarketActivityid");
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
                    MarketActivityNewEntry.GetHtmlInEditMode(MarketActivity);
                    vpMainPanel.Add(MarketActivityNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunMarketActivityDelete") + "&mact_MarketActivityid=" + mact_MarketActivityid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                    url = url.Replace("Key37", "MarketActivityid");
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
