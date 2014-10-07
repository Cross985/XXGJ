using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Competitor
{
    public class MarketActivityDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("mact_MarketActivityid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record MarketActivity = FindRecord("MarketActivity", "mact_MarketActivityid=" + id);
                string cpet_competitorid = MarketActivity.GetFieldAsString("mact_competitorid");
                EntryGroup MarketActivityNewEntry = new EntryGroup("MarketActivityNewEntry");
                MarketActivityNewEntry.Fill(MarketActivity);

                AddTabHead("Delete MarketActivity");
                if (hMode == "Delete")
                {
                    MarketActivity.DeleteRecord = true;
                    MarketActivity.SaveChanges();

                    ////double  =MarketActivity.GetFieldAsDouble("");
                    ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                    ////double  = BusReport.GetFieldAsDouble("");                        
                    //// =  - ;
                    ////BusReport.SetField("", );
                    ////BusReport.SaveChanges();

                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                    url = url.Replace("Key37", "MarketActivityid");
                    url = url + "&Key37=" + cpet_competitorid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    MarketActivityNewEntry.GetHtmlInViewMode(MarketActivity);
                    vpMainPanel.Add(MarketActivityNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
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
