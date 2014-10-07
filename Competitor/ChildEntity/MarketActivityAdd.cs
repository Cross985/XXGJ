using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace Competitor
{
    public class MarketActivityAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string cpet_competitorid = Dispatch.EitherField("cpet_competitorid");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup MarketActivityNewEntry = new EntryGroup("MarketActivityNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry bred_busreportidEntry = MarketActivityNewEntry.GetEntry("mact_competitorid");
                if (bred_busreportidEntry != null)
                {
                    bred_busreportidEntry.DefaultValue = cpet_competitorid;
                    bred_busreportidEntry.ReadOnly = true;
                }

                AddTabHead("MarketActivity");
                if (hMode == "Save")
                {
                    Record MarketActivity = new Record("MarketActivity");
                    MarketActivityNewEntry.Fill(MarketActivity);
                    if (MarketActivityNewEntry.Validate())
                    {
                        //QuerySelect s = new QuerySelect();
                        //string prefix = "bred" + DateTime.Now.ToString("yyyyMMdd");
                        //s.SQLCommand = "select count(*) as count from MarketActivity where bred_name like '" + prefix + "%'";
                        //s.ExecuteReader();
                        //int cnt = 0;
                        //if (!s.Eof())
                        //{
                        //    cnt = Convert.ToInt32(s.FieldValue("count"));
                        //}
                        //string code = string.Empty;
                        //code = prefix + (cnt + 1).ToString().PadLeft(4, '0');
                        //MarketActivity.SetField("bred_name", code);
                        MarketActivity.SaveChanges();
                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");
                        ////double  =MarketActivity.GetFieldAsDouble("");
                        //// =  + ;
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
                    if (errorflag == 2)
                    {
                        AddError(errormessage);
                    }

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    MarketActivityNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(MarketActivityNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
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
